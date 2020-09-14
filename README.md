# gsCompilarEjecutarNET
Utilidad para colorear código (de VB o C#), compilarlo y ejecutarlo desde la aplicación.<br>
Tanto para aplicaciones de consola como de Windows Forms.<br>
<br>
<br>
En la carpeta <b>preview</b> está el código fuente y el proyecto para Visual Basic, también habrá copias de los otros dos proyectos que utiliza esta utilidad:<br>
gsColorearNET y gsCompilarNET.<br>
Aunque te recomiendo que te descargues el código de esas dos de los repositorios que tengo en gitHub:<br>
gsColorearNET: https://github.com/elGuille-info/gsColorearNET<br>
gsCompilarNET: https://github.com/elGuille-info/gsCompilarNET<br>
<br>
<b>Nota:</b><br>
Esta versión utiliza .NET 5.0 Preview 8 y para usarla necesitarás Visual Studio 2019 Preview (yo estoy usando la versión Version 16.8.0 Preview 2.1.<br>
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
Actualizado el 14 de septiembre de 2020 a las 21:56 GMT+2<br>


