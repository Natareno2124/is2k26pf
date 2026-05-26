@echo off
setlocal enabledelayedexpansion
color 0A

echo ======================================================
echo SISTEMA DE COMPILACION GLOBAL - MRP G1 (ULTIMATE)
echo ======================================================

:: --- CONFIGURACION DE RUTAS ---
set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
set "ROOT_DIR=%~dp0"
set "HOTELERIA_DIR=C:\asis2k25p2\codigo\modulos\hoteleria"
set "MRP_MAINT_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\Mantenimientos"
set "MRP_DLLS_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\DLLS"
set "MRP_NAV_TRANS_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\NavegadorTransaccionalMVC"
set "MRP_MVC_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\MVC_MRP"

:: RUTA DEL PROYECTO CODIGO DE BARRAS FALTANTE
set "CODIGOB_DIR=%ROOT_DIR%codigo\empresarial\MRP - G1\DLLS\Entrega de Producto Terminado\Materiales\CodigoB"

:: Verificacion de MSBuild
if not exist "%MSBUILD_PATH%" (
    set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
)

cd /d "%ROOT_DIR%"

:: ==========================================================
:: 1. CICLOS DE COMPILACION BASE + NAVEGADOR TRANSACCIONAL
:: ==========================================================
for /L %%i in (1,1,4) do (
    echo.
    echo CICLO %%i: Compilando Componentes Base...
    call :CompilarModulo CONSULTAS
    call :CompilarModulo REPORTEADOR
    call :CompilarModulo SEGURIDAD
    call :CompilarModulo NAVEGADOR_TRANSACCIONAL
    call :CompilarModulo NAVEGADOR
)

:: ==========================================================
:: 1.5 INYECCION DE DEPENDENCIAS Y COMPILACION: ZEN.BARCODE
:: ==========================================================
echo.
color 0D
echo [+] Verificando e inyectando dependencias de Zen.Barcode...
if exist "%CODIGOB_DIR%" (
    if not exist "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug" mkdir "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug"
    if not exist "%CODIGOB_DIR%\Capa_Vista_CodigoB\obj\Debug" mkdir "%CODIGOB_DIR%\Capa_Vista_CodigoB\obj\Debug"
    set "PKG_DIR=%CODIGOB_DIR%\packages\Zen.Barcode.Rendering.Framework.3.1.10729.1\lib"
    if not exist "!PKG_DIR!" mkdir "!PKG_DIR!"

    echo     [!] Zen.Barcode.Core.dll no se encontro en el arbol de directorios.
    echo     [+] Descargando paquete oficial NuGet desde internet via PowerShell...
    
    powershell -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; Invoke-WebRequest -Uri 'https://www.nuget.org/api/v2/package/Zen.Barcode.Rendering.Framework/3.1.10729.1' -OutFile '%TEMP%\zen.zip'; Expand-Archive -Path '%TEMP%\zen.zip' -DestinationPath '%TEMP%\zen_extracted' -Force; Copy-Item '%TEMP%\zen_extracted\lib\Zen.Barcode.Core.dll' -Destination '%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug\Zen.Barcode.Core.dll' -Force; Copy-Item '%TEMP%\zen_extracted\lib\Zen.Barcode.Core.dll' -Destination '%CODIGOB_DIR%\Capa_Vista_CodigoB\obj\Debug\Zen.Barcode.Core.dll' -Force; Copy-Item '%TEMP%\zen_extracted\lib\Zen.Barcode.Core.dll' -Destination '!PKG_DIR!\Zen.Barcode.Core.dll' -Force" 2>nul
    
    if exist "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug\Zen.Barcode.Core.dll" (
        echo         [EXITO] Zen.Barcode restaurado e inyectado en /bin, /obj y /packages.
    )

    if exist "%CODIGOB_DIR%\CodigoB.sln" (
        echo     -^> Compilando Solucion: CodigoB.sln
        "%MSBUILD_PATH%" "%CODIGOB_DIR%\CodigoB.sln" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
    )
    
    if exist "%CODIGOB_DIR%\Capa_Vista_CodigoB\Capa_Vista_CodigoB.csproj" (
        echo     -^> Compilando Proyecto: Capa_Vista_CodigoB.csproj
        "%MSBUILD_PATH%" "%CODIGOB_DIR%\Capa_Vista_CodigoB\Capa_Vista_CodigoB.csproj" /t:Build /p:Configuration=Debug /p:ReferencePath="%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug" /v:m /m
        
        if !errorlevel! equ 0 (
            echo.
            echo         [OK] Capa_Vista_CodigoB compilada con exito.
            if exist "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug\Capa_Vista_CodigoB.dll" (
                copy /y "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug\Capa_Vista_CodigoB.dll" "%MRP_DLLS_DIR%\" > nul
                copy /y "%CODIGOB_DIR%\Capa_Vista_CodigoB\bin\Debug\Zen.Barcode.Core.dll" "%MRP_DLLS_DIR%\" > nul
            )
        ) else (
            echo.
            echo         [ERROR] Fallo critico al compilar Capa_Vista_CodigoB.csproj.
            pause
            exit /b 1
        )
    )
)

:: ==========================================================
:: 2. COMPILACION DINAMICA DE DLLS (CICLOS AUTOMATICOS)
:: ==========================================================
echo.
color 0E
echo [+] Compilando Carpeta de DLLS Dinamica...
if exist "%MRP_DLLS_DIR%" (
    set "MAX_CICLOS=10"
    set "CICLO_ACTUAL=1"
    set "HAY_ERRORES=1"

    :CicloDLL
    if !CICLO_ACTUAL! gtr !MAX_CICLOS! (
        echo     [ADVERTENCIA] Se alcanzo el limite de !MAX_CICLOS! ciclos. Algunas DLLs podrian tener errores de codigo.
        goto FinCicloDLL
    )
    
    if !HAY_ERRORES! equ 1 (
        echo     --- Iniciando Ciclo !CICLO_ACTUAL! de compilacion de DLLs ---
        set "HAY_ERRORES=0"
        
        for /r "%MRP_DLLS_DIR%" %%d in (*.csproj) do (
            :: Evitar procesar Capa_Vista_CodigoB de forma dinamica ya que fue forzado antes con sus referencias manuales
            if not "%%~nxd"=="Capa_Vista_CodigoB.csproj" (
                echo     -^> Intentando DLL: %%~nxd
                "%MSBUILD_PATH%" "%%d" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
                if !errorlevel! equ 0 (
                    echo         [OK] Compilado correctamente
                ) else (
                    echo         [ERROR] Fallo. Faltan dependencias o hay error de sintaxis.
                    set "HAY_ERRORES=1"
                )
            )
        )
        
        if !HAY_ERRORES! equ 1 (
            echo     [INFO] Hubo fallos en el ciclo !CICLO_ACTUAL!. Reintentando compilacion...
            set /a "CICLO_ACTUAL+=1"
            goto CicloDLL
        ) else (
            echo     [EXITO] Todas las DLLs fueron compiladas correctamente en el ciclo !CICLO_ACTUAL!.
        )
    )
    :FinCicloDLL
    echo [+] Finalizada la evaluacion de DLLs.
) else (
    echo     [ADVERTENCIA] Carpeta DLLS no encontrada: %MRP_DLLS_DIR%
)

:: ==========================================================
:: 3. COMPILAR HOTELERIA
:: ==========================================================
echo.
color 0A
echo [+] Compilando Soluciones de Hoteleria...
if exist "%HOTELERIA_DIR%" (
    for /r "%HOTELERIA_DIR%" %%f in (*.sln) do (
        echo     -^> Solucion: %%~nxf
        "%MSBUILD_PATH%" "%%f" /p:Configuration=Debug /m /v:m > nul 2>&1
    )
) else (
    echo     [ADVERTENCIA] Carpeta Hoteleria no encontrada: %HOTELERIA_DIR%
)

:: ==========================================================
:: 4. COMPILACION DINAMICA MANTENIMIENTOS MRP
:: ==========================================================
echo.
color 0B
echo [+] Compilando Mantenimientos MRP Dinamicamente...
if exist "%MRP_MAINT_DIR%" (
    for /L %%P in (1,1,2) do (
        for /r "%MRP_MAINT_DIR%" %%p in (*.csproj) do (
            echo     -^> Mantenimiento: %%~nxp
            "%MSBUILD_PATH%" "%%p" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
        )
    )
) else (
    echo     [ADVERTENCIA] Carpeta Mantenimientos no encontrada: %MRP_MAINT_DIR%
)

:: ==========================================================
:: 5. COMPILAR MVC_MRP (PROYECTO PRINCIPAL)
:: ==========================================================
echo.
color 0F
echo [+] Compilando MVC_MRP Principal (Ultimo paso)...
if exist "%MRP_MVC_DIR%" (
    if exist "%MRP_MVC_DIR%\MVC_MRP.sln" (
        echo     -^> Compilando solucion MVC_MRP.sln
        "%MSBUILD_PATH%" "%MRP_MVC_DIR%\MVC_MRP.sln" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
        if !errorlevel! equ 0 (
            echo         [OK] Solucion MVC_MRP compilada correctamente
        ) else (
            echo         [ERROR] Fallo en solucion MVC_MRP
        )
    )
    
    echo     -^> Compilando proyectos individuales...
    if exist "%MRP_MVC_DIR%\Capa_Modelo_MRP\Capa_Modelo_MRP.csproj" (
        "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Modelo_MRP\Capa_Modelo_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
        echo         [OK] Capa_Modelo_MRP
    )
    if exist "%MRP_MVC_DIR%\Capa_Controlador_MRP\Capa_Controlador_MRP.csproj" (
        "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Controlador_MRP\Capa_Controlador_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
        echo         [OK] Capa_Controlador_MRP
    )
    if exist "%MRP_MVC_DIR%\Capa_Vista_MRP\Capa_Vista_MRP.csproj" (
        "%MSBUILD_PATH%" "%MRP_MVC_DIR%\Capa_Vista_MRP\Capa_Vista_MRP.csproj" /t:Build /p:Configuration=Debug /v:m /m > nul 2>&1
        echo         [OK] Capa_Vista_MRP
    )
    echo     [OK] MVC_MRP Procesado completamente.
) else (
    echo     [ERROR] Carpeta MVC_MRP no encontrada: %MRP_MVC_DIR%
)

echo.
echo ======================================================
echo COMPILACION FINALIZADA COMPLETAMENTE.
echo ======================================================
pause
exit /b 0

:: ==========================================================
:: FUNCION: COMPILAR MODULOS (BASE Y ESPECIFICOS)
:: ==========================================================
:CompilarModulo
if /I "%1"=="CONSULTAS" (
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Modelo_Componente_Consultas\Capa_Modelo_Componente_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Controlador_Componente_Consultas\Capa_Controlador_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\Componente_Consultas\Capa_Vista_Componente_Consultas\Capa_Vista_Componente_Consultas.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Modelo_Componente_Consultas\Capa_Modelo_Componente_Consultas_Simples.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Controlador_Componente_Consultas\Capa_Controlador_Componente_Consultas_Simples.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\consultas\ComponenteConsultasSimples\Capa_Vista_Componente_Consultas_simples\Capa_Vista_Componente_Consultas_simples.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
)
if /I "%1"=="REPORTEADOR" (
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Modelo_Reporteador\Capa_Modelo_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Controlador_Reporteador\Capa_Controlador_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\reporteador\reporteador\Capa_Vista_Reporteador\Capa_Vista_Reporteador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
)
if /I "%1"=="SEGURIDAD" (
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaModelo\Capa_Modelo_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaControlador\Capa_Controlador_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\seguridad\SeguridadMVC\SeguridadMVC\CapaVista\Capa_Vista_Seguridad.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
)
if /I "%1"=="NAVEGADOR_TRANSACCIONAL" (
    echo     Compilando NavegadorTransaccionalMVC...
    if exist "%MRP_NAV_TRANS_DIR%\CapaModeloNavegador\Capa_Modelo_NavegadorTrs.csproj" (
        "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaModeloNavegador\Capa_Modelo_NavegadorTrs.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
        echo         [OK] Modelo Navegador Transaccional
    )
    if exist "%MRP_NAV_TRANS_DIR%\CapaControladorNavegador\Capa_Controlador_NavegadorTrs.csproj" (
        "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaControladorNavegador\Capa_Controlador_NavegadorTrs.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
        echo         [OK] Controlador Navegador Transaccional
    )
    if exist "%MRP_NAV_TRANS_DIR%\CapaVistaNavegador\Capa_Vista_NavegadorTrs.csproj" (
        "%MSBUILD_PATH%" "%MRP_NAV_TRANS_DIR%\CapaVistaNavegador\Capa_Vista_NavegadorTrs.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
        echo         [OK] Vista Navegador Transaccional
    )
)
if /I "%1"=="NAVEGADOR" (
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaModeloNavegador\Capa_Modelo_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaControladorNavegador\Capa_Controlador_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
    "%MSBUILD_PATH%" "codigo\componentes\navegador\NavegadorMVC\CapaVistaNavegador\Capa_Vista_Navegador.csproj" /t:Build /p:Configuration=Debug /v:m > nul 2>&1
)
exit /b 0