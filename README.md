# gsCompilarEjecutarNET
Utilidad para colorear código (de VB o C#), compilarlo y ejecutarlo desde la aplicación.<br>
Tanto para aplicaciones de consola como de Windows Forms.<br>
<br>
<br>
# Esta aplicación ya no tendrá más actualizaciones.
## En su lugar publicaré otra que incluirá evaluación del código y algunas utilidades más.
<br>
La he actualizado con fecha del 25 de octubre de 2020 y he puesto la recomendación de que se use:<br>
<b><a href="https://github.com/elGuille-info/gsEvaluarColorearCodigoNET">gsEvaluarColorearCodigoNET</a></b> (que no usa esta DLL, pero sí código mejorado y ampliado).<br>
<br>
En la carpeta <b>src</b> (antes preview) está el código fuente y el proyecto para Visual Basic, también habrá copias de los otros dos proyectos que utiliza esta utilidad:<br>
gsColorearNET y gsCompilarNET.<br>
Aunque te recomiendo que te descargues el código de esas dos de los repositorios que tengo en gitHub:<br>
gsColorearNET: https://github.com/elGuille-info/gsColorearNET<br>
gsCompilarNET: https://github.com/elGuille-info/gsCompilarNET<br>
<br>
También he añadido <b>gsCompilarEjecutarNET cs</b>, la utilidad convertida a código de C#.<br>
<br>
<b>Nota:</b><br>
Esta versión utiliza .NET 5.0 RC2 y para usarla necesitarás Visual Studio 2019 Preview (yo estoy usando la versión Version 16.8.0 Preview 5.0.<br>
El editor de Windows Forms para Visual Basic deja mucho que desear, e incluso no me funcionan ni los <b>Settings</b> ni los <b>recursos</b> y tampoco <b>My</b>.<br>
Por eso he tenido que asignar manualmente los métodos de eventos y si usara imágenes en los menús, etc., también tendría que asignarlos manualmente.<br>
Esto último no es una suposición, ya que lo tengo comprobado en la utilidad <a href="https://github.com/elGuille-info/gsColorearCodigoNET">gsColorearCodigoNET</a>.<br>
Así que... si te descargas el código y ves que es una patata... no es todo culpa mía ;-)<br>
<br>
Acabo de ver un aviso de que ya está lista para la descarga la versión 16.8.0 Preview 3.0<br>
La descargo y te cuento.<br>
Sigue <i>casi igual</i>, ya que aunque ahora define los controles con WithEvents, al hacer doble-clic en ellos, crea el método de evento predeterminado (Click para el control Button, Load para el formulario) pero no añade el Handle y por tanto no está ligado con el copntrol.<br>
Ni siquiera crea el método de evento asociado si eliges el evento desde la ventana de propiedades.<br>
Y si haces nuevamente doble-clic, te vuelve a crear otro método de evento con otro nombre, al estilo de Button2_Click_1<br>
Esto lo he com probado usando .NET 5.0 preview como para .NET Core 3.1<br>
En fin... habrá que seguir esperando...<br>
<br>
<br>
Por si decido quitar las referencias a los proyectos y usar las DLL compiladas de las dos bibliotecas usadas en la utilidad, aquí te dejo los enlaces a los paquetes NuGet por si decides descargarlos y usarlos con Visual Studio 2019 preview:<br>
gsColorearNET: https://www.nuget.org/packages/gsColorearNET/<br>
gsCompilarNET: https://www.nuget.org/packages/gsCompilarNET/<br>
<br>
<br>
Guillermo<br>
<br>
Actualizado el 25 de octubre de 2020 a eso de las 14:23 GMT+2<br>
<br>
<br>
<h2>Revisiones</h2>
v1.0.0.20 Avisar cada día... ¡hasta que se cambien! ;-)<br>
v1.0.0.19 La primera vez que se inicia se muestra el aviso.<br>
v1.0.0.18 Recomendación de usar gsEvaluarColorearCodigoNET.<br>
v1.0.0.17 Mostrar los números de líneas. No se mostraba por culpa del tipo de retorno de línea.<br>
Hago comprobación del tipo de retorno de carro (línea) tiene el texto.<br>
v1.0.0.16 Comprobación de si la posición guardada del formulario está en el área visible.<br>
v1.0.0.15 Uso .NET 5.0 RC2 y las actualizaciones de gsColorearNET y gsCompilarNET.<br>
v1.0.0.14 Quito la clase gsColorearNET y uso los módulos ColorizeSupport, etc.<br>
(25/Oct/20) Creo que no quité nada... se sigue usando la biblioteca gsColorearNET<br>
v1.0.0.13 Añado un menú contextual al editor de código con los comandos de edición.<br>
v1.0.0.12 Se puede indicar la versión de los lenguajes.<br>
Se usa Latest para VB y Default (9.0) para C#.<br>
v1.0.0.11 Nueva opción para compilar sin ejecutar y otras mejoras visuales.<br>
v1.0.0.10 Con panel para buscar y reemplazar y funciones para buscar, buscar siguiente, reemplazar y reemplazar todos.<br>
También en el menú de edición están las 5 opciones.<br>
v1.0.0.9 Opciones de Buscar y Reemplazar.<br>
Pongo WordWrap del RichTextBox a False para que no corte las líneas.<br>
<br>
v1.0.0.8 del 17 de septiembre de 2020 (con esta fecfha dije que no la actualizaría más)<br>
Actualizado con las nuevas versiones de gsColorearNET (v1.0.0.8) gsCompilarNET (v1.0.0.2)<br>
<br>
v1.0.0.7 del 15 y 16 de septiembre de 2020<br>
Añado control para mostrar los números de líneas.<br>
Se sincronizan los dos RichTexBox (el código y los números de líneas).<br>
Añado la versión de la utilidad en AcercaDe.<br>
Corrigo algunos fallos como no tener enlazado el evento Click del menú Nuevo.<br>
Fallaba al abrir un fichero que no existe.<br>
Si cargarUltimo era False al estar asignado ultimoFic si se intentaba abrir ese fichero, no lo abría.<br>
<br>
Actualizo el código de gsColorearNET a la versión 1.0.0.7 del 16 de septiemrbe de 2020<br>
Añado el proyecto en C# de la utilidad (convertirdo desde el último publicado de Visual Basic .NET<br>
<br>
v1.0.0.6 del 15 de septiembre de 2020:<br>
El formulario principal muestra las líneas de código y se sincroniza con el código<br>
Modifico el AcercaDe mostrando la versión de la utilidad.<br>
