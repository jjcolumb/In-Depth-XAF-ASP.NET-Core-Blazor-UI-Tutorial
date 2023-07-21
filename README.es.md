[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/edit/master/README.md)
# In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial (En español)

Mientras continuamos ampliando las capacidades de la interfaz de usuario de ASP.NET Core Blazor de XAF, puede ofrecer experiencias de usuario intuitivas para la plataforma ASP.NET Core Blazor. Este tutorial documenta cómo crear una aplicación para almacenar contactos y otros objetos relacionados utilizando la interfaz de usuario de ASP.NET Core Blazor de XAF.

[![imagen](https://user-images.githubusercontent.com/126447472/254449600-2fb62d4c-bd5d-4602-9588-2677c29ff038.png)](https://user-images.githubusercontent.com/126447472/254449600-2fb62d4c-bd5d-4602-9588-2677c29ff038.png)

Si es nuevo en XAF, asegúrese de revisar nuestra página de  [productos XAF](https://www.devexpress.com/products/net/application_framework/)  para obtener información importante sobre nuestro galardonado marco de aplicación.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#dependencies-and-prerequisites)Dependencias y requisitos previos

Antes de comenzar el tutorial, lea esta sección y asegúrese de que se cumplen las siguientes condiciones:

1.  [Visual Studio 2022 v17.0+](https://visualstudio.microsoft.com/)  (con la carga de trabajo de desarrollo web y ASP.NET) está instalado en el equipo. Tiene experiencia básica en el desarrollo de .NET Framework en este IDE.
2.  [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)  está instalado en el equipo.
3.  Una versión de  [prueba gratuita de 30 días](https://www.devexpress.com/products/try/)  o una versión con licencia de  [DevExpress Universal Subscription](https://www.devexpress.com/Subscriptions/Universal.xml)  está instalada en su equipo.
4.  Tiene conocimientos básicos de los conceptos de  [asignación relacional de objetos (ORM)](https://en.wikipedia.org/wiki/Object-relational_mapping)  y de  [DevExpress XPO.](https://www.devexpress.com/products/net/orm/)
5.  Cualquier  [RDBMS](https://en.wikipedia.org/wiki/Relational_database_management_system)  compatible con la herramienta XPO ORM (consulte Sistemas de bases de datos  [compatibles con XPO)](https://docs.devexpress.com/XPO/2114/product-information/database-systems-supported-by-xpo?v=22.1)  se instala y se puede acceder a él desde el equipo para almacenar los datos de la aplicación (se recomienda una instancia de LocalDB o SQL Server Express).
6.  Está familiarizado con la  [arquitectura de aplicaciones XAF](https://docs.devexpress.com/eXpressAppFramework/112559/overview/architecture?v=22.1).

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#tutorial-structure)Estructura del tutorial

Este tutorial está organizado de la siguiente manera:

-   Diseño de Modelo de Negocio

En esta sección se explica cómo implementar clases que definen la base del modelo de negocio de la aplicación y su estructura de base de datos asociada.

-   Amplíe la funcionalidad

En esta sección se explica cómo ampliar la interfaz de usuario generada automáticamente de XAF con comandos personalizados.

-   Personalización de la interfaz de usuario

En esta sección se explica cómo personalizar la interfaz de usuario de la aplicación Core Blazor ASP.NET generada automáticamente por XAF.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#connection-string)Cadena de conexión

Este tutorial utiliza SQL Server de Microsoft como su sistema de administración de bases de datos (DBMS) de destino. Como ya sabrá, XAF admite múltiples sistemas de administración de bases de datos (consulte la lista  [aquí](https://docs.devexpress.com/XPO/2114/product-information/database-systems-supported-by-xpo?v=22.1)). Si desea utilizar un DBMS diferente, asegúrese de especificar la  [cadena de conexión](https://docs.devexpress.com/XPO/2114/product-information/database-systems-supported-by-xpo?v=22.1#how-to-create-a-correct-connection-string)  adecuada.

Las aplicaciones XAF crean una base de datos con un nombre que coincide con el nombre utilizado para la propia solución. Para cambiar los nombres, edite la cadena de conexión en el archivo de configuración de la aplicación (_appsettings.json_).

Para volver a crear la base de datos, suéltela del servidor de bases de datos o elimine el archivo. La aplicación XAF volverá a crear la base de datos en el siguiente inicio.

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#business-model-design)Diseño de Modelo de Negocio

En esta sección se explica cómo diseñar un modelo de negocio (base de datos) para una aplicación creada con eXpressApp Framework.

Aprenderá a completar las siguientes tareas:

-   Crear clases de negocio asignadas a tablas de base de datos
-   Especificar relaciones entre clases
-   Implementar propiedades dependientes
-   Agregar validación de valor de propiedad

Puede diseñar un modelo de negocio de cualquiera de las siguientes maneras:

-   **Usar la biblioteca de clases empresariales de DevExpress**
    
    La  [biblioteca de](https://docs.devexpress.com/eXpressAppFramework/112571/business-model-design-orm/built-in-business-classes-and-interfaces?v=22.1)  clases empresariales incluye clases empresariales de uso frecuente, como  **Persona**,  **Evento**,  **Tarea**, etc. Puede utilizar una clase de esta biblioteca tal cual, o heredarla y ampliarla.
    
-   **Crear clases personalizadas**
    
    Si utiliza  **XPO,**  herede los objetos de negocio de  [las clases persistentes base](https://docs.devexpress.com/eXpressAppFramework/113146/business-model-design-orm/business-model-design-with-xpo/base-persistent-classes?v=22.1).
    

> SUGERENCIA: Para obtener información sobre cómo crear una aplicación basada en una base de datos existente, consulte el tema siguiente:  [Cómo: Generar clases empresariales de XPO para tablas de datos existentes](https://docs.devexpress.com/eXpressAppFramework/113451/business-model-design-orm/business-model-design-with-xpo/generate-xpo-business-classes-for-existing-data-tables?v=22.1).

Una vez que complete el tutorial, su aplicación básica ASP.NET Core Blazor CRUD se verá como se muestra en la imagen a continuación.

[![imagen](https://user-images.githubusercontent.com/126447472/254449669-5a718a0c-9d18-4006-9805-92b7a9b0aa7c.png)](https://user-images.githubusercontent.com/126447472/254449669-5a718a0c-9d18-4006-9805-92b7a9b0aa7c.png)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#create-a-solution-xpo)Crear una solución (XPO)

Esta lección crea una nueva solución XAF y le guía a través del Asistente para soluciones XAF. En el asistente, hará lo siguiente:

-   Agregue un proyecto de interfaz de usuario de Blazor a la solución.
-   Seleccione una herramienta ORM para usarla en la administración de datos.
-   Active la autenticación de usuario.
-   Revise los módulos integrados disponibles y habilite el módulo de validación.

Al final de esta lección, puede ejecutar la aplicación por primera vez.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions)Instrucciones paso a paso

1.  En el menú principal de Visual Studio, seleccione  **Archivo**  |  **Nuevo**  |  **Proyecto...**  para invocar el cuadro de diálogo  **Crear un nuevo proyecto**.
    
2.  Seleccione  **DevExpress v22.1 XAF Template Gallery**  y haga clic en  **Siguiente**. Especifique el nombre del proyecto ("MiSolución") y haga clic en  **Crear**.
    

[![imagen](https://user-images.githubusercontent.com/126447472/254449701-631824c0-69aa-49f9-9475-d4091a3b842c.png)](https://user-images.githubusercontent.com/126447472/254449701-631824c0-69aa-49f9-9475-d4091a3b842c.png)

3.  En la ventana Galería de plantillas invocada, cambie a la sección .**NET Core.**  Seleccione  **Asistente para soluciones XAF (.NET Core)**  y haga clic en  **Ejecutar asistente**.

[![imagen](https://user-images.githubusercontent.com/126447472/254449755-bd227acf-8d91-4d27-bb3f-b4acdad57d71.png)](https://user-images.githubusercontent.com/126447472/254449755-bd227acf-8d91-4d27-bb3f-b4acdad57d71.png)

4.  En la primera página del Asistente para soluciones, puede seleccionar la plataforma de destino. Dado que este tutorial solo muestra la interfaz de usuario de Blazor, seleccione la opción  **Web (ASP.NET Core Blazor)**  y haga clic en  **Siguiente**.

[![imagen](https://user-images.githubusercontent.com/126447472/254449775-7d5ffb5f-8649-4a1c-8b6c-8dae60448fe3.png)](https://user-images.githubusercontent.com/126447472/254449775-7d5ffb5f-8649-4a1c-8b6c-8dae60448fe3.png)

5.  Elija la biblioteca ORM de  [objetos persistentes de DevExpress eXpress](https://docs.devexpress.com/XPO/7969/product-information/main-features?v=22.1).

[![imagen](https://user-images.githubusercontent.com/126447472/254449789-ce4f917c-668c-4488-915a-69f32cee240b.png)](https://user-images.githubusercontent.com/126447472/254449789-ce4f917c-668c-4488-915a-69f32cee240b.png)

6.  Elija el tipo de autenticación para su aplicación. En este tutorial, usamos  **Standard**. Haga clic en  **Siguiente**.

[![imagen](https://user-images.githubusercontent.com/126447472/254449810-65f2383c-af1c-4c70-b505-037b061624df.png)](https://user-images.githubusercontent.com/126447472/254449810-65f2383c-af1c-4c70-b505-037b061624df.png)

7.  Select the ready-to-use XAF modules you want to add to your application. This tutorial requires the  **Validation**  module. Click  **Finish**.

[![imagen](https://user-images.githubusercontent.com/126447472/254449829-7af6f1d6-cea4-44b8-8b41-3f77e6164b58.png)](https://user-images.githubusercontent.com/126447472/254449829-7af6f1d6-cea4-44b8-8b41-3f77e6164b58.png)

``
The solution contains the following projects:

-   **MySolution.Blazor.Server**  - the ASP.NET Core Blazor application project that automatically generates the ASP.NET Core Blazor CRUD user interface. This project depends on the  _MySolution.Module_.
-   **MySolution.Module**  - the  [module](https://docs.devexpress.com/eXpressAppFramework/118046/application-shell-and-base-infrastructure/application-solution-components/modules?v=22.1)  project that contains platform-independent code.
    
   ![image](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/assets/126447472/73ff27a5-2867-4821-b517-d6d4dc2533e6)

    

Refer to the  [Application Solution Structure](https://docs.devexpress.com/eXpressAppFramework/118045/application-shell-and-base-infrastructure/application-solution-components/application-solution-structure?v=22.1)  topic for information on the XAF solution structure.


8.  Ahora puede ejecutar la aplicación. Haga clic en  **Iniciar depuración**  o presione F5.
    
    Las siguientes imágenes muestran la aplicación ASP.NET Core Blazor. Inicie sesión como "Admin" y use una cadena vacía como contraseña.
    

[![imagen](https://user-images.githubusercontent.com/126447472/254449942-22e74d91-0cc2-4411-bced-2b16b5d92d45.png)](https://user-images.githubusercontent.com/126447472/254449942-22e74d91-0cc2-4411-bced-2b16b5d92d45.png)

[![imagen](https://user-images.githubusercontent.com/126447472/254449965-948a5241-72a8-42db-841d-0319acdcd1d1.png)](https://user-images.githubusercontent.com/126447472/254449965-948a5241-72a8-42db-841d-0319acdcd1d1.png)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#initial-connection-to-database)Conexión inicial a la base de datos

El asistente intenta buscar la instancia de  **Microsoft SQL Server**  instalada (**LocalDB**  o  **Express**) y establece la cadena de conexión en consecuencia.

Consulte el tema  [Conectar una aplicación XAF a un proveedor](https://docs.devexpress.com/eXpressAppFramework/113155/business-model-design-orm/connect-an-xaf-application-to-a-database-provider?v=22.1)  de bases de datos para obtener más información sobre cómo conectarse a diferentes sistemas de bases de datos.

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#inherit-from-the-business-class-library-class-xpo)Heredar de la clase de biblioteca de clase empresarial (XPO)

En esta lección, aprenderá a implementar clases de negocio para su aplicación mediante la  [Biblioteca de clases empresariales](https://docs.devexpress.com/eXpressAppFramework/112571/business-model-design-orm/built-in-business-classes-and-interfaces?v=22.1). Esta biblioteca contiene las clases de negocios listas para usar más típicas. Implementará una clase  **Contact**  personalizada derivando de la clase  **Person**  disponible en esta biblioteca e implementará varias propiedades adicionales. También aprenderá los conceptos básicos de la construcción automática de la interfaz de usuario basada en datos.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-1)Instrucciones paso a paso

1.  Haga clic con el botón secundario en la carpeta  _Business Objects_  del proyecto  _MySolution.Module_  y elija  **Agregar elemento**  |  **Clase...**, especifique  _Contacto.cs_  como el nuevo nombre de clase y haga clic en  **Agregar**.
    
2.  Reemplace la declaración de clase generada por el código siguiente.
    ```csharp
    using DevExpress.Persistent.Base;
    using DevExpress.Persistent.BaseImpl;
    using DevExpress.Persistent.Validation;
    using DevExpress.Xpo;
    using System;
    
    namespace MySolution.Module.BusinessObjects {
        [DefaultClassOptions]
        public class Contact : Person {
            public Contact(Session session) : base(session) { }
            private string webPageAddress;
            public string WebPageAddress {
                get { return webPageAddress; }
                set { SetPropertyValue(nameof(WebPageAddress), ref webPageAddress, value); }
            }
            private string nickName;
            public string NickName {
                get { return nickName; }
                set { SetPropertyValue(nameof(NickName), ref nickName, value); }
            }
            private string spouseName;
            public string SpouseName {
                get { return spouseName; }
                set { SetPropertyValue(nameof(SpouseName), ref spouseName, value); }
            }
            private TitleOfCourtesy titleOfCourtesy;
            public TitleOfCourtesy TitleOfCourtesy {
                get { return titleOfCourtesy; }
                set { SetPropertyValue(nameof(TitleOfCourtesy), ref titleOfCourtesy, value); }
            }
            private DateTime anniversary;
            public DateTime Anniversary {
                get { return anniversary; }
                set { SetPropertyValue(nameof(Anniversary), ref anniversary, value); }
            }
            private string notes;
            [Size(4096)]
            public string Notes {
                get { return notes; }
                set { SetPropertyValue(nameof(Notes), ref notes, value); }
            }
        }
        public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };
    }
    ```
3.  Ejecute la aplicación.
    
    XAF genera una interfaz de usuario basada en las estructuras de datos especificadas:
    
    -   una  **vista de lista**
        
        La vista de lista muestra la lista de  **contactos**. Si los usuarios hacen clic en el botón  **Nuevo**  o en un registro existente, la aplicación muestra un formulario de detalle ([Vista detallada](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1)) lleno de editores para cada campo de datos.
        
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254450041-97c4164e-f936-47f3-b9f2-82453e6ca1e6.png)](https://user-images.githubusercontent.com/126447472/254450041-97c4164e-f936-47f3-b9f2-82453e6ca1e6.png)
    
    -   Una  **vista detallada**
        
        [![imagen](https://user-images.githubusercontent.com/126447472/254450064-fa0f648c-8dd2-44a1-ae20-bc1f0e9fcde5.png)](https://user-images.githubusercontent.com/126447472/254450064-fa0f648c-8dd2-44a1-ae20-bc1f0e9fcde5.png)
        

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#detailed-explanation)Explicación detallada

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#convention)Convención

Normalmente, las clases de negocio no dependen de la interfaz de usuario de la aplicación y deben implementarse en un  [proyecto de módulo independiente de la plataforma](https://docs.devexpress.com/eXpressAppFramework/118045/application-shell-and-base-infrastructure/application-solution-components/application-solution-structure?v=22.1). Los objetos de negocio se pueden compartir con otras aplicaciones XAF o no XAF.

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#add-a-business-object)Agregar un objeto de negocio

En esta lección, derivamos el objeto  **Contact**  de la clase  **Person**. La clase  **Persona**  es una de las clases de  [Biblioteca de clase Business](https://docs.devexpress.com/eXpressAppFramework/112571/business-model-design-orm/built-in-business-classes-and-interfaces?v=22.1). Esta clase ya contiene campos específicos para entidades del tipo Persona: nombre, apellido, fecha de nacimiento, etc.

La clase  **Person**  (y el resto de la biblioteca de clases Business) deriva de  [BaseObject](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.BaseImpl.BaseObject?v=22.1). La clase  **BaseObject**  deriva de  [DevExpress.Xpo.XPCustomObject](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPCustomObject?v=22.1), una de las clases base de XPO. Esto significa que el objeto de negocio  **Contact**  es un  _objeto persistente_.

XPO requiere que implemente colocadores de propiedades y un constructor parametrizado de la siguiente manera:
```csharp
[DefaultClassOptions]
public class Contact : Person {
    public Contact(Session session) : base(session) { }
    private string webPageAddress;
    public string WebPageAddress {
        get { return webPageAddress; }
        set { SetPropertyValue(nameof(WebPageAddress), ref webPageAddress, value); }
    }
    // ...
}
```
Consulte el siguiente tema de ayuda para obtener más información:  [Creación de un objeto persistente](https://docs.devexpress.com/XPO/2077/create-a-data-model/create-a-persistent-object?v=22.1).

Para obtener información general sobre el concepto de clase empresarial, consulte el tema siguiente:  [Clases empresariales frente a tablas de base de datos](https://docs.devexpress.com/eXpressAppFramework/112570/business-model-design-orm/business-model-design-with-xpo/business-classes-vs-database-tables?v=22.1).

> NOTA
> 
> [CodeRush](https://www.devexpress.com/products/coderush/)  incluye una serie de plantillas de código que ayudan a generar clases de negocio o sus partes con unas pocas pulsaciones de teclas. Para obtener información sobre las plantillas de código para  **objetos persistentes de eXpress**, consulte el siguiente tema de ayuda:  [Plantillas XPO y XAF](https://docs.devexpress.com/CodeRushForRoslyn/118557/coding-assistance/code-templates/xpo-templates?v=22.1).

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#attributes)Atributos

En este tutorial, la clase de objetos de negocio se decora con el atributo  [DefaultClassOptionsAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.DefaultClassOptionsAttribute?v=22.1). Este atributo significa que las siguientes capacidades están disponibles para la clase empresarial  **Contact**.

-   El elemento  **Contacto**  se agrega al control de navegación de la página principal. Los usuarios pueden hacer clic en este elemento para acceder a la  [vista de lista](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1)  asociada.

[![imagen](https://user-images.githubusercontent.com/126447472/254450254-eb48c8f8-35ad-42eb-aca8-81798652f9b1.png)](https://user-images.githubusercontent.com/126447472/254450254-eb48c8f8-35ad-42eb-aca8-81798652f9b1.png)

-   **Los**  objetos de contacto se pueden usar como origen de datos para generar informes (vea  [Crear un informe en Visual Studio](https://docs.devexpress.com/eXpressAppFramework/112734/getting-started/in-depth-tutorial-winforms-webforms/extra-modules/create-a-report-in-visual-studio?v=22.1)).

Para aplicar cada una de estas opciones por separado, utilice los atributos  [NavigationItemAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.NavigationItemAttribute?v=22.1)  y  [VisibleInReportsAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.VisibleInReportsAttribute?v=22.1).

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#user-interface)Interfaz de usuario

XAF genera los editores adecuados para los campos de datos en la vista de lista y la vista de detalle. Por ejemplo, se genera un selector de fecha para los valores de fecha y hora, se crea un editor de cuadros combinados para  **Título de cortesía**  (un enumerador).

XAF transforma los subtítulos de camel-case a cadenas separadas por espacios, se actualizan los títulos de los formularios, etc.

Puede utilizar las funciones de cuadrícula en una vista de lista en tiempo de ejecución: reorganizar columnas y ordenar y filtrar datos:

[![imagen](https://user-images.githubusercontent.com/126447472/254450327-87576281-feb1-4f65-ac8c-c1078fdde812.png)](https://user-images.githubusercontent.com/126447472/254450327-87576281-feb1-4f65-ac8c-c1078fdde812.png)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#supply-initial-data-xpo)Suministro de datos iniciales (XPO)

> NOTA: Antes de continuar, tómese un momento para revisar la lección  [Heredar de la clase de biblioteca de clase empresarial (XPO](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)).

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-2)Instrucciones paso a paso

1.  Abra el archivo  _Updater.cs_  ubicado en la carpeta  _Actualización de base de datos_  del proyecto  _MySolution.Module._  Agregue el código siguiente al método  [ModuleUpdater.UpdateDatabaseAfterUpdateSchema.](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater.UpdateDatabaseAfterUpdateSchema?v=22.1)
    ```csharp
    using MySolution.Module.BusinessObjects;
    //...
    
    public class Updater : DevExpress.ExpressApp.Updating.ModuleUpdater {
        //...
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
    
            Contact contactMary = ObjectSpace.FirstOrDefault<Contact>(contact => contact.FirstName == "Mary" && contact.LastName == "Tellitson"); 
            if (contactMary == null) {
                contactMary = ObjectSpace.CreateObject<Contact>();
                contactMary.FirstName = "Mary";
                contactMary.LastName = "Tellitson";
                contactMary.Email = "tellitson@example.com";
                contactMary.Birthday = new DateTime(1980, 11, 27);
            }
            //...
            ObjectSpace.CommitChanges();
        }
    }
    ```
2.  Ejecute la aplicación. Seleccione el elemento  **Contacto**  en el control de navegación. Observe que el nuevo contacto, "Mary Tellitson", aparece en la lista de la derecha.
    

[![imagen](https://user-images.githubusercontent.com/126447472/254450347-55421825-d9b7-4062-9566-d154706ec52c.png)](https://user-images.githubusercontent.com/126447472/254450347-55421825-d9b7-4062-9566-d154706ec52c.png)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#detailed-explanation-1)Explicación detallada

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#database-update)Actualización de la base de datos

En el paso 1, agregue un código que comprueba si la lista de contactos contiene una entrada que coincide con el nombre "Mary Tellitson". Si dicho contacto no existe, el código lo crea y lo agrega a la base de datos.

Una aplicación  **XAF**  comprueba la compatibilidad de versiones de aplicaciones y bases de datos en cada inicio. Se realizan las siguientes comprobaciones:

-   La base de datos existe.
-   Todas las tablas necesarias existen.
-   Todas las columnas obligatorias existen.

El evento  [XafApplication.DatabaseVersionMismatch](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.XafApplication.DatabaseVersionMismatch?v=22.1)  se produce si se produce un error en alguna de estas comprobaciones.

La aplicación ASP.NET Core Blazor controla este evento en una plantilla de solución. Cuando la aplicación se ejecuta en modo de depuración, este controlador de eventos utiliza el actualizador de base de datos integrado para actualizar la  **base de datos de**  la aplicación. Después de actualizar el esquema de base de datos, se llama al método  [ModuleUpdater.UpdateDatabaseAfterUpdateSchema.](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater.UpdateDatabaseAfterUpdateSchema?v=22.1)  En este método, puede guardar los objetos de negocio necesarios en la base de datos.

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#query-data)Consultar datos

Como puede ver en el código anterior, XAF utiliza un objeto  [Object Space](https://docs.devexpress.com/eXpressAppFramework/113707/data-manipulation-and-business-logic/object-space?v=22.1)  para manipular objetos persistentes (consulte Crear,  [leer, actualizar y eliminar datos](https://docs.devexpress.com/eXpressAppFramework/113711/data-manipulation-and-business-logic/create-read-update-and-delete-data?v=22.1)).

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#implement-custom-business-classes-and-reference-properties-xpo)Implementar clases empresariales personalizadas y propiedades de referencia (XPO)

Esta lección explica los siguientes conceptos:

-   Cómo implementar clases de negocio desde cero
-   Cómo implementar referencias de objetos a clases existentes
-   Cómo XAF genera la interfaz de usuario para los objetos a los que se hace referencia

> NOTA Antes de continuar, tómese un momento para revisar la lección anterior:  [Heredar de la clase de biblioteca de clase empresarial (XPO).](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-3)Instrucciones paso a paso

1.  Agregue las siguientes clases persistentes  **Department**  y  **Position**  al archivo  _Contact.cs_.
    ```csharp
    namespace MySolution.Module.BusinessObjects {
        // ... 
        [DefaultClassOptions]
        [System.ComponentModel.DefaultProperty(nameof(Title))]
        public class Department : BaseObject {
            public Department(Session session) : base(session) { }
            private string title;
            public string Title {
                get { return title; }
                set { SetPropertyValue(nameof(Title), ref title, value); }
            }
            private string office;
            public string Office {
                get { return office; }
                set { SetPropertyValue(nameof(Office), ref office, value); }
            }
        }
        [DefaultClassOptions]
        [System.ComponentModel.DefaultProperty(nameof(Title))]
        public class Position : BaseObject {
            public Position(Session session) : base(session) { }
            private string title;
            public string Title {
                get { return title; }
                set { SetPropertyValue(nameof(Title), ref title, value); }
            }
        }
    }
    ```
2.  Agregue las propiedades  **Department**  y  **Position**  a la clase  **Contact**:
    ```csharp
    [DefaultClassOptions]
    public class Contact : Person {
        //...
        private Department department;
        public Department Department {
            get {return department;}
            set {SetPropertyValue(nameof(Department), ref department, value);}
        }
        private Position position;
        public Position Position {
            get {return position;}
            set {SetPropertyValue(nameof(Position), ref position, value);}
        }
        //...
    }
    ```
    La clase  **Contact**  ahora expone las propiedades de referencia  **Position**  y  **Department**.
    
3.  Ejecute la aplicación.
    
    Después de ejecutar la aplicación, puede ver que el control de navegación muestra dos elementos nuevos:  **Departamento**  y  **Posición**. Puede hacer clic en los nuevos elementos para acceder a las listas de departamentos y puestos.
    
    -   Formulario de detalle del departamento:
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254450389-bfff4ef5-b622-4e99-887e-40c63e93cd61.png)](https://user-images.githubusercontent.com/126447472/254450389-bfff4ef5-b622-4e99-887e-40c63e93cd61.png)
    
    -   Lista de departamentos:
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254450408-c26d36cc-179c-4e40-a9f1-80a3b7fb7e8c.png)](https://user-images.githubusercontent.com/126447472/254450408-c26d36cc-179c-4e40-a9f1-80a3b7fb7e8c.png)
    
    En la vista Detalles de  **contacto**, XAF crea editores de búsqueda para  **Departamento**  y  **Puesto**. Estos editores utilizan un tipo especial de vista: la  [vista](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1)  de lista de búsqueda. Normalmente, esta vista incluye una sola columna que muestra los valores de la propiedad predeterminada de la clase. Consulte información adicional acerca de las propiedades predeterminadas más adelante en este tema.
    

[![imagen](https://user-images.githubusercontent.com/126447472/254450484-ae43a917-c22c-4dac-873d-8ea680edac6c.png)](https://user-images.githubusercontent.com/126447472/254450484-ae43a917-c22c-4dac-873d-8ea680edac6c.png)

Los usuarios pueden seleccionar valores de Departamento o Posición de las listas desplegables. Tenga en cuenta que los editores de búsqueda admiten el filtrado incremental:



[![imagen](https://user-images.githubusercontent.com/126447472/254450544-ed127eea-a884-4a16-bca8-a159d55b9b3f.png)](https://user-images.githubusercontent.com/126447472/254450544-ed127eea-a884-4a16-bca8-a159d55b9b3f.png)  

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#detailed-explanation-2)Explicación detallada

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#default-property)Default (propiedad)

Las clases  **Position**  y  **Department**  están decoradas con el atributo  **DefaultProperty**. Este atributo especifica la  [propiedad predeterminada](https://docs.devexpress.com/eXpressAppFramework/113525/business-model-design-orm/how-to-specify-a-display-member-for-a-lookup-editor-detail-form-caption?v=22.1)  de la clase. Puede especificar la propiedad más descriptiva de la clase en el atributo  **DefaultProperty**  y, a continuación, sus valores se mostrarán en lo siguiente:

-   Leyendas de formulario de detalle
-   La columna situada más a la izquierda de una vista de lista
-   Vistas de lista de búsqueda

Consulte el tema  [Anotaciones de datos en el modelo de datos](https://docs.devexpress.com/eXpressAppFramework/112701/business-model-design-orm/data-annotations-in-data-model?v=22.1)  para obtener más información.


# Establecer una relación de varios a varios (XPO)

En esta lección se explica cómo crear una relación de varios a varios entre objetos de negocio y cómo XAF genera la interfaz de usuario para dichas relaciones.

> NOTA Antes de continuar, tómese un momento para revisar la lección anterior:  [Heredar de la clase de biblioteca de clase empresarial (XPO).](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-4)Instrucciones paso a paso

1.  Haga clic con el botón secundario en la carpeta  _Business Objects_  del proyecto  _MySolution.Module_  y elija  **Agregar**  |  **Clase...**. Cambie el nombre del archivo a  _Tarea.cs_  y haga clic en  **Agregar**. Reemplace el contenido del nuevo archivo con el código siguiente:
    ```csharp
    using DevExpress.ExpressApp.Model;
    using DevExpress.Persistent.Base;
    using DevExpress.Persistent.BaseImpl;
    using DevExpress.Xpo;
    
    namespace MySolution.Module.BusinessObjects {
        [DefaultClassOptions]
        [ModelDefault("Caption", "Task")]
        public class DemoTask : Task {
            public DemoTask(Session session) : base(session) { }
            [Association("Contact-DemoTask")]
            public XPCollection<Contact> Contacts {
                get {
                    return GetCollection<Contact>(nameof(Contacts));
                }
            }
        }
    }
    ```
2.  Agregue la propiedad  **Tasks**  en la implementación de la clase  **Contact**.
    ```csharp
    [DefaultClassOptions]
    public class Contact : Person {
        //...
        [Association("Contact-DemoTask")]
        public XPCollection<DemoTask> Tasks {
            get {
                return GetCollection<DemoTask>(nameof(Tasks));
            }
        }
    }
    ```
3.  Ejecute la aplicación.
    
    En la vista Detalles de  **contacto**, la aplicación muestra los siguientes elementos:
    
    1.  Una lista de tareas asignadas;
    2.  El botón  **Nuevo**  - permite a los usuarios agregar una nueva tarea asignada;
    3.  El botón  **Vincular**: permite a los usuarios asignar al contacto actual una tarea existente.

[![imagen](https://user-images.githubusercontent.com/126447472/254450609-f1b22b03-deac-4248-bc1e-3b3d04d4644c.png)](https://user-images.githubusercontent.com/126447472/254450609-f1b22b03-deac-4248-bc1e-3b3d04d4644c.png)


You can find the same UI in the  **Tasks**  detail view.



![imagen](https://user-images.githubusercontent.com/126447472/254450668-db3b8cf7-44a9-4214-824f-5139b9c64ab7.png)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#detailed-explanation-3)Explicación detallada

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#add-an-association)Agregar una asociación

En la clase  _DemoTask_,  [AssociationAttribute](https://docs.devexpress.com/XPO/DevExpress.Xpo.AssociationAttribute?v=22.1)  se aplica a la propiedad  **Contacts**  del tipo  [XPCollection](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPCollection?v=22.1). Esta propiedad representa una colección de contactos asociados. XPO utiliza el atributo  **Association**  para establecer una relación entre objetos. La implementación del getter de propiedades  **Contacts**  (el método  **GetCollection**) se utiliza para devolver una colección.
```csharp
[Association("Contact-DemoTask")]
public XPCollection<Contact> Contacts {
    get {
        return GetCollection<Contact>(nameof(Contacts));
    }
}
```
En la clase Contact, la propiedad  **Tasks**  es la segunda parte de la relación  **Contact-DemoTask**.  Tenga en cuenta que el atributo  **Association**  también debe aplicarse a esta propiedad.
```csharp
[DefaultClassOptions]
public class Contact : Person {
    //...
    [Association("Contact-DemoTask")]
    public XPCollection<DemoTask> Tasks {
        get {
            return GetCollection<DemoTask>(nameof(Tasks));
        }
    }
}
```
> NOTA No modifique la declaración  **de propiedad XPCollection**  demostrada anteriormente. Si manipula la colección o introduce cualquier configuración adicional dentro de la declaración, puede provocar un comportamiento impredecible.

Después de ejecutar la aplicación, XPO generará las tablas y relaciones intermedias.

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#change-application-model-in-code)Cambiar el modelo de aplicación en el código

La clase  **DemoTask**  está decorada con el atributo  [ModelDefaultAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Model.ModelDefaultAttribute?v=22.1). Los parámetros de atributo especifican que la propiedad  **Caption**  de  **BOModel**  |  **El nodo DemoTask**  se establece en "Tarea".

Puede aplicar el atributo  **ModelDefault**  a una clase de negocio o a su miembro para cambiar cualquier propiedad de la  **lista de materiales del modelo**  de aplicación |  o  **BOModel**  |  |  **Miembros Propios**  |  nodo.

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#set-a-one-to-many-relationship-xpo)Establecer una relación de uno a varios (XPO)

En esta lección se explica cómo crear una relación de uno a varios entre objetos de negocio y cómo XAF genera la interfaz de usuario para dicha relación.

> NOTA Antes de continuar, tómese un momento para repasar las lecciones anteriores:

-   [Heredar de la clase de biblioteca de clase empresarial (XPO)](https://docs.devexpress.com/eXpressAppFramework/112718/getting-started/in-depth-tutorial-winforms-webforms/business-model-design/inherit-from-the-business-class-library-class-xpo?v=22.1)
-   [Implementar clases empresariales personalizadas y propiedades de referencia (XPO)](https://docs.devexpress.com/eXpressAppFramework/112732/getting-started/in-depth-tutorial-winforms-webforms/business-model-design/implement-custom-business-classes-and-reference-properties-xpo?v=22.1)
-   [Establecer una relación de varios a varios (XPO)](https://docs.devexpress.com/eXpressAppFramework/112719/getting-started/in-depth-tutorial-winforms-webforms/business-model-design/set-a-many-to-many-relationship-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-5)Instrucciones paso a paso

1.  Para implementar la parte "One" de la relación  _Departamento-Contactos_, decore la propiedad  **Department**  de la clase  **Contact**  con  [AssociationAttribute](https://docs.devexpress.com/XPO/DevExpress.Xpo.AssociationAttribute?v=22.1).
    ```csharp
    [DefaultClassOptions]
    public class Contact : Person {
        //...
        private Department department;
        [Association("Department-Contacts")]
        public Department Department {
            get {return department;}
            set {SetPropertyValue(nameof(Department), ref department, value);}
        }
        //...
    }
    ```
    Consulte el siguiente tema de ayuda para obtener información sobre el atributo  **Asociación**:  [Establecer una relación de varios a varios (XPO).](https://docs.devexpress.com/eXpressAppFramework/112719/getting-started/in-depth-tutorial-winforms-webforms/business-model-design/set-a-many-to-many-relationship-xpo?v=22.1)
    
2.  Para implementar la parte "Muchos" de la relación  _Departamento-Contactos_, agregue la propiedad  **Contacts**  a la clase  **Department**  y decore esta propiedad con el atributo  **Association**.
    ```csharp
    public class Department : BaseObject {
        //...
        [Association("Department-Contacts")]
        public XPCollection<Contact> Contacts {
            get {
                return GetCollection<Contact>(nameof(Contacts));
            }
        }
    }
    ```
3.  Ejecute la aplicación.
    
    Abra la vista de detalles del  **departamento**. Puede ver el grupo  **Contactos**. Para agregar objetos a la colección  **Contactos**, utilice el botón  **Nuevo**  o  **Vínculo**  de esta ficha. El botón  **Vínculo**  permite a los usuarios agregar referencias a objetos  **de contacto**  existentes.
    

[![imagen](https://user-images.githubusercontent.com/126447472/254450774-a4a1656a-61dc-4d24-8757-b12d77eff526.png)](https://user-images.githubusercontent.com/126447472/254450774-a4a1656a-61dc-4d24-8757-b12d77eff526.png)


To remove a reference to an object from this collection, use the  **Unlink**  button.

![image](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/assets/126447472/a46750a4-53b0-4bca-8cce-79b9e5e59fa7)



> TIP: Si crea un nuevo departamento y, a continuación, crea un nuevo contacto en la colección  **Contactos**, el  **departamento**  asociado no es visible inmediatamente en la  [vista detallada](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1)  del  **contacto**  recién creado.  El vínculo entre estos objetos se agrega más adelante al guardar el  **contacto**. Para cambiar este comportamiento, utilice la propiedad  [XafApplication.LinkNewObjectToParentImmediately .](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.XafApplication.LinkNewObjectToParentImmediately?v=22.1)  `true`. Cuando el valor de la propiedad es , la aplicación crea un vínculo y lo guarda inmediatamente después de hacer clic en  **Nuevo**.``

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#initialize-business-object-properties-xpo)Inicializar propiedades de objeto de negocio (XPO)

En esta lección se explica cómo inicializar propiedades en objetos de negocio recién creados.

Para ello, agregará la propiedad  **Priority**  a la clase  **DemoTask**  creada en la lección  [Set a Many-to-Many Relationship (XPO](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)). A continuación, reemplazará el método  **AfterConstruction**  para inicializar la nueva propiedad.

> NOTA Antes de continuar, tómese un momento para repasar las lecciones anteriores:
> 
> -   [Heredar de la clase de biblioteca de clase empresarial (XPO)](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)
> -   [Establecer una relación de varios a varios (XPO)](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-6)Instrucciones paso a paso

1.  Agregue la  propiedad Priority a la clase  **DemoTask**  y declare la enumeración  **Priority**, como se muestra a continuación:
    ```csharp
    public class DemoTask : Task {
        // ...
        private Priority priority;
        public Priority Priority {
            get { return priority; }
            set {
                SetPropertyValue(nameof(Priority), ref priority, value);
            }
        }
        //...
    }
    public enum Priority {
        Low,
        Normal,
        High
    }
    ```
2.  Para inicializar la propiedad  **Priority**  recién agregada cuando se crea un objeto  **DemoTask**, invalide el método  **AfterConstruction**, como se muestra a continuación:
    ```csharp
    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task {
        //...
        public override void AfterConstruction() {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }
        //...
    }
    ```
3.  Ejecute la aplicación.
    
    Cree un nuevo objeto  **DemoTask**. En la vista Detalles de la tarea, la propiedad  **Priority**  se establece en , como se indica en el código anterior.`Priority.Normal`
    

[![imagen](https://user-images.githubusercontent.com/126447472/254450830-6e2cbf82-8bdb-41e7-a482-405b58f60942.png)](https://user-images.githubusercontent.com/126447472/254450830-6e2cbf82-8bdb-41e7-a482-405b58f60942.png)

Tenga en cuenta que XAF genera un cuadro combinado para la propiedad  **Priority**. Los elementos del cuadro combinado son los valores de enumeración declarados en el paso 2.

[![imagen](https://user-images.githubusercontent.com/126447472/254450847-25123438-9e12-4207-bdad-c2c24b6b169d.png)](https://user-images.githubusercontent.com/126447472/254450847-25123438-9e12-4207-bdad-c2c24b6b169d.png)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#detailed-explanation-4)Explicación detallada

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#initialize-property-values)Inicializar valores de propiedad

El método  [AfterConstruction](https://docs.devexpress.com/XPO/DevExpress.Xpo.PersistentBase.AfterConstruction?v=22.1)  se ejecuta cuando se crea un nuevo objeto de negocio. En este tutorial, reemplazará este método para establecer la propiedad  **Priority**  cuando se crea un nuevo objeto  **DemoTask**.`Priority.Normal`

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#implement-dependent-reference-properties-xpo)Implementar propiedades de referencia dependientes (XPO)

En esta lección se explica cómo implementar propiedades cuyos valores pueden depender de otras propiedades.

Agregará una nueva propiedad  **Manager**  a la clase  **Contact**. El editor de esta propiedad mostrará una lista de los administradores que trabajan en el mismo departamento.

[![imagen](https://user-images.githubusercontent.com/126447472/254450909-26e9cbad-aa8e-4b28-8baa-b190ddf1ff97.png)](https://user-images.githubusercontent.com/126447472/254450909-26e9cbad-aa8e-4b28-8baa-b190ddf1ff97.png)

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Heredar de la clase de biblioteca de clase empresarial (XPO)](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)
> -   [Implementar clases empresariales personalizadas y propiedades de referencia (XPO)](https://docs.devexpress.com/eXpressAppFramework/402163/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-custom-business-classes-and-reference-properties-xpo?v=22.1)
> -   [Establecer una relación de uno a varios (XPO)](https://docs.devexpress.com/eXpressAppFramework/402169/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-one-to-many-relationship-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-7)Instrucciones paso a paso

1.  Agregue una nueva propiedad  **Manager**  del tipo Contact a la clase  **Contact**.
    
    
    
    ```csharp
    [DefaultClassOptions]
    public class Contact : Person {
        //...
        private Contact manager;
        public Contact Manager {
           get { return manager; }
           set { SetPropertyValue(nameof(Manager), ref manager, value); }
        }
        //...
    }
    
    
    ```
    
2.  Aplique los atributos  **DataSourceProperty**  y  **DataSourceCriteria**  a la propiedad recién agregada.
    ```csharp
    [DefaultClassOptions]
    public class Contact : Person {
        //...
        [DataSourceProperty("Department.Contacts", DataSourcePropertyIsNullMode.SelectAll)]
        [DataSourceCriteria("Position.Title = 'Manager' AND Oid != '@This.Oid'")]
        public Contact Manager {
            // ...
        }
        // ...
    }
    ```
3.  Ejecute la aplicación.
    
    Agregue los siguientes objetos:
    
    -   un objeto Department (por ejemplo, "Developer  **Department**")
    -   varios objetos  **Contact**  con la propiedad Department establecida en "Developer  **Department**"
    -   varios objetos  **Position**  (por ejemplo, "Manager", "Developer").
    
    Para los contactos recién agregados, establezca la propiedad  **Position**  en:
    
    -   "Manager" (para varios objetos  **de contacto**);
    -   "Desarrollador" (para otros objetos  **de contacto**).
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254450941-423d5331-f76c-4bee-a34a-9b2c404059a4.png)](https://user-images.githubusercontent.com/126447472/254450941-423d5331-f76c-4bee-a34a-9b2c404059a4.png)
    
    Cree un nuevo objeto  **Contact**. En la Vista de detalles de  **contacto**, especifique la propiedad  **Department**  y expanda el editor de búsquedas  **del administrador**. Tenga en cuenta lo siguiente:
    
    -   La propiedad  **Department**  de los objetos enumerados es la misma que la especificada anteriormente.
    -   La propiedad  **Position**  se establece en "Manager" para cada uno de los objetos enumerados.
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254450958-b75d0ab8-1454-4e55-a774-edeecefb0a91.png)](https://user-images.githubusercontent.com/126447472/254450958-b75d0ab8-1454-4e55-a774-edeecefb0a91.png)
    

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#detailed-explanation-5)Explicación detallada

Puede utilizar diseñadores XAF integrados para implementar el mismo comportamiento sin código. Para obtener más información, consulte la siguiente lección:  [Filtrar origen de datos para un editor de búsquedas](https://docs.devexpress.com/eXpressAppFramework/404170/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/filter-data-source-for-lookup-editor-xpo?v=22.1).

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#the-datasourceproperty-attribute)El atributo DataSourceProperty

El atributo  **DataSourceProperty**  acepta dos parámetros. El primero especifica la ruta a la lista de búsqueda. El segundo parámetro es opcional. Especifica cómo se rellenan los elementos de búsqueda si la aplicación no pudo encontrar ningún elemento de la ruta de acceso.

En este tutorial, el segundo parámetro se establece en  [SelectAll](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.DataSourcePropertyIsNullMode?v=22.1). También puede establecer los valores  [SelectNothing](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.DataSourcePropertyIsNullMode?v=22.1)  o  [CustomCriteria](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.DataSourcePropertyIsNullMode?v=22.1). En este último caso, se requiere un tercer parámetro para especificar los criterios.

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#the-datasourcecriteria-attribute)El atributo DataSourceCriteria

Con el atributo  **DataSourceCriteria**  aplicado, el editor de búsquedas  **del Administrador**  contiene objetos  **Contact**  que satisfacen los criterios especificados en el parámetro attribute.


# Implementar la validación del valor de la propiedad en el código (XPO)

En esta lección se explica cómo establecer reglas de validación para las clases empresariales y sus propiedades. XAF aplica estas reglas cuando un usuario ejecuta la operación especificada (por ejemplo, guarda un objeto editado).

En esta lección creará una regla que requiere que la propiedad  **Position.Title**  no esté vacía. La aplicación aplicará la regla cuando un usuario guarde un objeto  **Position**.

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Heredar de la clase de biblioteca de clase empresarial (XPO)](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)
> -   [Implementar clases empresariales personalizadas y propiedades de referencia (XPO)](https://docs.devexpress.com/eXpressAppFramework/402163/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-custom-business-classes-and-reference-properties-xpo?v=22.1)

> NOTA Para usar la funcionalidad de validación de XAF, instale el paquete NuGet y  [registre](https://docs.devexpress.com/eXpressAppFramework/118047/application-shell-and-base-infrastructure/application-solution-components/ways-to-register-a-module?v=22.1)  el módulo de validación en el proyecto.`DevExpress.ExpressApp.Validation.Blazor`

El asistente para proyectos agrega este paquete a todas las aplicaciones nuevas con las opciones de seguridad habilitadas.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-8)Instrucciones paso a paso

1.  Aplique el atributo  [RuleRequiredFieldAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Validation.RuleRequiredFieldAttribute?v=22.1)  a la propiedad  **Title**  de la clase  **Position**. Como parámetro, especifique el contexto que desencadena la regla (por ejemplo, ):`DefaultContexts.Save`
    ```csharp
    using DevExpress.Persistent.Validation;
    //...
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty(nameof(Title))]
    public class Position : BaseObject {
       //...
       private string title;
       [RuleRequiredField(DefaultContexts.Save)]
       public string Title {
          get { return title; }
          set { SetPropertyValue(nameof(Title), ref title, value); }
       }
    }
    ```
2.  Ejecute la aplicación.
    
    Haga clic en el botón  **Nuevo**  para crear un nuevo objeto  **Posición**. Deje vacía la propiedad  **Title**  y haga clic en  **Guardar**. Se muestra el mensaje de error:
    
    ![image](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/assets/126447472/cb6f6154-a5ca-44c7-be9a-50d808702427)

    

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#detailed-explanation-6)Explicación detallada

El atributo  **RuleRequiredField**  define una regla de validación que garantiza que la propiedad Position.Title tiene un valor cuando se guarda el objeto  **Position.**

El Sistema de Validación ofrece una serie de reglas y contextos. Para obtener más información, consulte el tema  [Reglas de validación](https://docs.devexpress.com/eXpressAppFramework/113008/validation/validation-rules?v=22.1). El modelo de aplicación almacena todas las reglas para que un administrador pueda agregar y editar reglas y contextos con el  [Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1)  (consulte el tema Implementar validación de  [valor de propiedad en el tema Modelo de aplicación](https://docs.devexpress.com/eXpressAppFramework/402142/getting-started/in-depth-tutorial-blazor/ui-customization/implement-property-value-validation-in-the-application-model?v=22.1)).

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#filter-data-source-for-a-lookup-editor-xpo)Filtrar origen de datos para un editor de búsquedas (XPO)

En esta lección se explica cómo filtrar los datos mostrados en un editor de búsquedas. Este editor aparece en una vista de detalle para las propiedades de referencia y contiene una lista de objetos de otra clase relacionada.

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Heredar de la clase de biblioteca de clase empresarial](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)
> -   [Implementar clases empresariales personalizadas y propiedades de referencia](https://docs.devexpress.com/eXpressAppFramework/402163/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-custom-business-classes-and-reference-properties-xpo?v=22.1)
> -   [Implementar propiedades de referencia dependientes](https://docs.devexpress.com/eXpressAppFramework/402164/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-dependent-reference-properties-xpo?v=22.1)
> -   [Establecer una relación de muchos a muchos](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-9)Instrucciones paso a paso

1.  Especifique una relación de varios a varios entre las clases y. Para obtener más información, consulte el tema siguiente:  [Establecer una relación de varios a varios (XPO).](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)`Position``Department`
    ```csharp
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty(nameof(Title))]
     public class Department : BaseObject {
       //...
       [Association("Departments-Positions")]
       public XPCollection<Position> Positions {
          get { return GetCollection<Position>(nameof(Positions)); }
       }
    }
    
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty(nameof(Title))]
    public class Position : BaseObject {
          //...
       [Association("Departments-Positions")]
       public XPCollection<Department> Departments {
          get { return GetCollection<Department>(nameof(Departments)); }
       }
    }
    ```
    ----------
    
2.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Vaya a la  **lista de materiales**  |  **Nodo MySolution.Module.BusinessObjects.**  Expanda el nodo secundario  **Contactar**  y seleccione  **OwnMembers**  |  **Colocar**  nodo secundario.
    
    Realice los siguientes cambios en las propiedades del nodo:
    
    -   Establezca la propiedad  **DataSourceProperty**  en .`Department.Positions`
    -   Establezca la propiedad  **DataSourcePropertyIsNullMode**  en .`SelectAll`
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451029-e1864139-0986-4330-a74e-fc6e0bafe7d7.png)](https://user-images.githubusercontent.com/126447472/254451029-e1864139-0986-4330-a74e-fc6e0bafe7d7.png)
    
3.  En la  clase Contact (_BusinessObjects\Contact.cs_), reemplace la declaración de propiedad por el código siguiente:`Department`
    ```csharp
    [Association("Department-Contacts", typeof(Department)), ImmediatePostData]
    public Department Department {
       get {return department;}
       set {
          SetPropertyValue(nameof(Department), ref department, value);
           // Clear Position and Manager properties if the Department has changed.
          if(!IsLoading) {
             Position = null;
             if(Manager != null && Manager.Department != value) {
                Manager = null;
             }
          }
       }
    }
    ```
    ----------
    
4.  Ejecute la aplicación. Abra la vista detallada de un departamento y vincule varios elementos de  **posición**  a este departamento.
    
5.  Abra la vista detallada de un contacto que pertenezca a este departamento. El menú desplegable Editor de posiciones enumera las  **posiciones**  que vinculaste en el paso anterior:
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451053-1f9d614c-0c38-4bb0-a8e7-a8233da681d9.png)](https://user-images.githubusercontent.com/126447472/254451053-1f9d614c-0c38-4bb0-a8e7-a8233da681d9.png)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#extend-functionality)Amplíe la funcionalidad

Antes de continuar con esta sección del tutorial, debe familiarizarse con los siguientes conceptos básicos de  **eXpressApp Framework**.

**Acción**

Visualmente, Action es un elemento de la barra de herramientas u otro control que realiza el código asociado cuando un usuario final lo manipula. XAF tiene varios tipos de acción predefinidos. Puede elegir el tipo adecuado en función de cómo desee que se muestre la acción dentro de la interfaz de usuario. Todas las acciones exponen el evento  **Execute**  cuyo controlador se ejecuta cuando los usuarios finales manipulan el elemento correspondiente. Para obtener más información, consulte el tema  [Acciones](https://docs.devexpress.com/eXpressAppFramework/112622/ui-construction/controllers-and-actions/actions?v=22.1).

**Controlador**

Los controladores son clases heredadas de la clase  [Controller](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Controller?v=22.1). Esta clase tiene los siguientes descendientes que también pueden servir como clases base para controladores:

-   ViewController y sus versiones genéricas: ViewController y  [ObjectViewController<ViewType, ObjectType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ObjectViewController-2?v=22.1)[](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController?v=22.1)[](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController-1?v=22.1)
-   [WindowController](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.WindowController?v=22.1)

Los controladores  [implementan la lógica empresarial en la](https://docs.devexpress.com/eXpressAppFramework/113711/data-manipulation-and-business-logic/create-read-update-and-delete-data?v=22.1)  aplicación. Esta lógica se ejecuta automáticamente (por ejemplo, al activar una vista) o se activa cuando un usuario ejecuta una acción declarada dentro del controlador. XAF utiliza la  [reflexión](https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection)  para recopilar automáticamente los controladores implementados dentro de los módulos. Las clases de controlador deben ser  _públicas_. Las propiedades del controlador y la clase base determinan una vista o una ventana donde este controlador está activo. Para obtener más información, consulte el tema  [Controladores](https://docs.devexpress.com/eXpressAppFramework/112621/ui-construction/controllers-and-actions/controllers?v=22.1).

Los controladores y las acciones son instrumentos que implementan características personalizadas en una aplicación XAF. En esta sección del tutorial, aprenderá cómo agregar acciones de diferentes tipos, implementar controladores sin acciones y modificar el comportamiento de controladores y acciones existentes. Se recomienda que complete las lecciones en el siguiente orden:

-   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)
-   [Agregar una acción parametrizada](https://docs.devexpress.com/eXpressAppFramework/402155/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-parametrized-action?v=22.1)
-   [Agregar una acción que muestre una ventana emergente](https://docs.devexpress.com/eXpressAppFramework/402158/getting-started/in-depth-tutorial-blazor/extend-functionality/add-an-action-that-displays-a-pop-up-window?v=22.1)
-   [Agregar una acción con selección de opción](https://docs.devexpress.com/eXpressAppFramework/402159/getting-started/in-depth-tutorial-blazor/extend-functionality/add-an-action-with-option-selection?v=22.1)
-   [Agregar una acción simple mediante un atributo](https://docs.devexpress.com/eXpressAppFramework/402156/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action-using-an-attribute?v=22.1)
-   [Configuración del editor de acceso](https://docs.devexpress.com/eXpressAppFramework/402153/getting-started/in-depth-tutorial-blazor/extend-functionality/access-editor-settings?v=22.1)
-   [Configuración de control de cuadrícula de acceso](https://docs.devexpress.com/eXpressAppFramework/402154/getting-started/in-depth-tutorial-blazor/extend-functionality/access-data-grid-settings?v=22.1)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#add-a-simple-action-net-6)Agregar una acción simple (.NET 6)

Esta lección explica cómo crear una  **acción simple**.

Una  **acción simple**  es un botón que ejecuta código personalizado cuando un usuario hace clic en él.

Las instrucciones siguientes muestran cómo agregar el botón  **Borrar tareas**  a la Vista de detalles de  **contacto**. Un clic en este botón borra todas las  **tareas rastreadas**  del  **contacto**  específico.

[![imagen](https://user-images.githubusercontent.com/126447472/254451291-2037b4c7-c3dd-4afc-88a1-13534022fcd3.png)](https://user-images.githubusercontent.com/126447472/254451291-2037b4c7-c3dd-4afc-88a1-13534022fcd3.png)

> NOTA Antes de continuar, tómese un momento para repasar las lecciones anteriores:
> 
> -   Heredar de la clase de biblioteca de clase empresarial ([XPO)](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1))
> -   Implementar clases empresariales personalizadas y propiedades de referencia ([XPO)](https://docs.devexpress.com/eXpressAppFramework/402163/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-custom-business-classes-and-reference-properties-xpo?v=22.1))
> -   Establecer una relación de varios a varios ([XPO](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1))

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/tree/master#step-by-step-instructions-10)Instrucciones paso a paso

1.  Agregar un controlador de vista. En el  **Explorador de soluciones**, haga clic con el botón secundario en la carpeta  _Controllers_  del proyecto  _MySolution.Module_  y elija  **Agregar elemento DevExpress**  |  **Nuevo artículo...**  para invocar la  [Galería de plantillas](https://docs.devexpress.com/eXpressAppFramework/113455/installation-upgrade-version-history/visual-studio-integration/template-gallery?v=22.1). Seleccione los  **controladores XAF**  |  **Controlador de vista**  Plantilla de Visual Studio, especifique  _ClearContactTasksController_  como nombre del nuevo elemento y haga clic en  **Agregar elemento**.

[![imagen](https://user-images.githubusercontent.com/126447472/254451309-a09d959c-b02a-44ff-9f08-6e83585bcbf3.png)](https://user-images.githubusercontent.com/126447472/254451309-a09d959c-b02a-44ff-9f08-6e83585bcbf3.png)

2.  Visual Studio muestra un archivo  _ClearContactTasksController.cs_  generado automáticamente con una sola declaración de View Controller. En el constructor del controlador, especifique las propiedades del controlador:
    
    using DevExpress.ExpressApp;
    ```csharp
    //...
    public partial class ClearContactTasksController : ViewController {
        public ClearContactTasksController() {
            InitializeComponent();
            //Activate the Controller only in the Detail View
            TargetViewType = ViewType.DetailView;
            //Specify the type of objects that can use the Controller
            TargetObjectType = typeof(Contact);
        }
    // ...
    ```
    Si no especifica la propiedad, la aplicación muestra las acciones del controlador para cada formulario de detalle.`TargetObjectType`
    

> PROPINA También puede crear un objeto genérico ViewController u  [ObjectViewController<ViewType, ObjectType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ObjectViewController-2?v=22.1)  y especificar el tipo de destino como parámetro.[](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController-1?v=22.1)  Para obtener más información sobre cómo personalizar la funcionalidad del controlador, consulte el tema siguiente:  [Definir el ámbito de los controladores y las acciones](https://docs.devexpress.com/eXpressAppFramework/113103/ui-construction/controllers-and-actions/define-the-scope-of-controllers-and-actions?v=22.1).`ViewType`

3.  Agregue una nueva acción al controlador y un controlador para el evento de la acción:`Execute`
    ```csharp
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Actions;
    using DevExpress.Persistent.Base;
    using MySolution.Module.BusinessObjects;
     //...
    public partial class ClearContactTasksController : ViewController {
        public ClearContactTasksController() {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Contact);
    
            SimpleAction clearTasksAction = new SimpleAction(this, "ClearTaskAction", PredefinedCategory.View) {
                //Specify the Action's button caption.
                Caption = "Clear tasks",
                //Specify the confirmation message that pops up when a user executes an Action.
                ConfirmationMessage = "Are you sure you want to clear the Tasks list?",
                //Specify the icon of the Action's button in the interface.
                ImageName = "Action_Clear"
            };
            //This event fires when a user clicks the Simple Action control.
            clearTasksAction.Execute += ClearTasksAction_Execute;
        }
        private void ClearTasksAction_Execute(Object sender, SimpleActionExecuteEventArgs e) {
            while(((Contact)View.CurrentObject).Tasks.Count > 0) {
                ((Contact)View.CurrentObject).Tasks.Remove(((Contact)View.CurrentObject).Tasks[0]);
                ObjectSpace.SetModified(View.CurrentObject);
            }
        }
    // ...
    ```
    Puede  [utilizar una de las imágenes estándar](https://docs.devexpress.com/eXpressAppFramework/112745/getting-started/in-depth-tutorial-winforms-webforms/ui-customization/assign-a-standard-image?v=22.1)  como icono del botón de la acción o  [importar la suya propia](https://docs.devexpress.com/eXpressAppFramework/112744/getting-started/in-depth-tutorial-winforms-webforms/ui-customization/assign-a-custom-image?v=22.1).
    
    El punto de entrada principal de una acción simple es su evento  **Execute**. Controle este evento para ejecutar código personalizado.
    
4.  Ejecute la aplicación.
    
    Abra un formulario de detalles para un elemento  **de contacto**. Vincule varias tareas a este elemento y guárdelo.
    
    Haga clic en el botón  **Borrar tareas**. Aparecerá un mensaje de confirmación. Haga clic en  **Aceptar**  para eliminar todas las  **tareas**  del  **contacto**  actual.
    
    ![image](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/assets/126447472/127eb34a-b18b-403e-84dd-7dbadba17108)

    

> TIP: Puede mostrar el botón de una acción en un diseño de vista detallada en lugar de en una barra de herramientas:  [Cómo: Incluir una acción en un diseño de vista detallada](https://docs.devexpress.com/eXpressAppFramework/112816/ui-construction/view-items-and-property-editors/include-an-action-to-a-detail-view-layout?v=22.1).


# Agregar una acción parametrizada (.NET 6)

En esta lección se explica cómo agregar una  **acción parametrizada**. La acción  **parametrizada**  muestra un editor que permite a los usuarios escribir un valor de parámetro antes de ejecutar la acción.

Las instrucciones siguientes muestran cómo implementar un nuevo controlador de vista con una acción parametrizada. Esta acción busca un objeto  **DemoTask**  por su valor de propiedad  **Subject**  y muestra el formulario de detalle del objeto encontrado.

> NOTA Antes de continuar, tómese un momento para repasar las lecciones anteriores:
> 
> -   **Heredar de la clase de biblioteca de clase empresarial**  (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   **Inicialización de propiedades de objeto de negocio**  (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402167/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/initialize-a-property-after-creating-an-object-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402982/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/initialize-a-property-after-creating-an-object-ef-core?v=22.1)))
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-11)Instrucciones paso a paso

1.  Agregue un nuevo controlador de View al proyecto  _MySolution.Module_, como se describe en la lección  [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1). Asígnele  _el nombre FindBySubjectController_.
    
2.  En  _MySolution.Module_  |  _Controladores_  |  _FindBySubjectController.cs_  archivo, especifique las propiedades del controlador:
    ```csharp
    using DevExpress.ExpressApp;
    // ...
    public partial class FindBySubjectController : ViewController {
        public FindBySubjectController() {
            InitializeComponent();
            //Activate the controller only in the List View.
            TargetViewType = ViewType.ListView;
            //Activate the controller only for root Views.
            TargetViewNesting = Nesting.Root;
            //Specify the type of objects that can use the controller.
            TargetObjectType = typeof(DemoTask);
        }
        // ...
    }
    ```
    Para obtener más información acerca de la vista raíz, consulte el tema siguiente:  [IsRoot](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.View.IsRoot?v=22.1).
    
3.  Agregue una acción parametrizada al controlador:
    ```csharp
    public partial class FindBySubjectController : ViewController {
        public FindBySubjectController() {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Root;
            TargetObjectType = typeof(DemoTask);
    
            ParametrizedAction findBySubjectAction =
                new ParametrizedAction(this, "FindBySubjectAction", PredefinedCategory.View, typeof(string)) {
                    ImageName= "Action_Search",
                    NullValuePrompt = "Find task by subject..."
                };
            findBySubjectAction.Execute += FindBySubjectAction_Execute;
        }
    // ...
    }
    ```
    Un usuario envía una cadena en el editor de la acción. Esto provoca el evento  [ParametrizedAction.Execute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.ParametrizedAction.Execute?v=22.1)  de la acción.
    
4.  Controlar el evento de la acción:`Execute`
    ```csharp
    public partial class FindBySubjectController : ViewController {
        public FindBySubjectController() {
         // ...
            findBySubjectAction.Execute += FindBySubjectAction_Execute;
        }
        private void FindBySubjectAction_Execute(object sender, ParametrizedActionExecuteEventArgs e) {
            var objectType = ((ListView)View).ObjectTypeInfo.Type;
            IObjectSpace objectSpace = Application.CreateObjectSpace(objectType);
            string paramValue = e.ParameterCurrentValue as string;
            object obj = objectSpace.FindObject(objectType, 
                CriteriaOperator.Parse("Contains([Subject], ?)",  paramValue));
            if(obj != null) {
                DetailView detailView = Application.CreateDetailView(objectSpace, obj);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ShowViewParameters.CreatedView = detailView;
            }
        }
    // ...
    }
    ```
    Para obtener más información sobre la implementación del controlador de eventos, consulte la sección  [Explicación detallada](https://docs.devexpress.com/eXpressAppFramework/402155/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-parametrized-action?v=22.1#detailed-explanation).
    
5.  Ejecute la aplicación.
    
    Seleccione el elemento  **Tarea**  en el control de navegación (el editor  **Buscar tarea por asunto**  es la acción que implementó). Escriba una palabra del  **asunto**  de una tarea existente en este editor y presione Entrar. La aplicación muestra un formulario de detalles con esta tarea.
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451574-2e578011-0306-4edd-abf2-46f927ba54bf.png)](https://user-images.githubusercontent.com/126447472/254451574-2e578011-0306-4edd-abf2-46f927ba54bf.png)
    
    ## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#detailed-explanation-7)Explicación detallada
    

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#search-implementation)Implementación de búsqueda

En XAF, se utiliza el  [espacio](https://docs.devexpress.com/eXpressAppFramework/113707/data-manipulation-and-business-logic/object-space?v=22.1)  de objetos para consultar y actualizar objetos persistentes. Llame al método estático  [XafApplication.CreateObjectSpace](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.XafApplication.CreateObjectSpace.overloads?v=22.1)  para crear un espacio de objetos.

Utilice el método  [IObjectSpace.FindObject](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.IObjectSpace.FindObject.overloads?v=22.1)  para buscar un objeto. Este método tiene los siguientes parámetros:`DemoTask`

-   Tipo de los objetos mostrados en la vista de lista actual. Utilice  [View.ObjectTypeInfo.](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.View.ObjectTypeInfo?v=22.1)
-   Criterios de búsqueda. Para generar un criterio, cree un objeto y pase componentes de criterios como parámetros del constructor. Para obtener más información, consulte la siguiente documentación de XPO:  [Sintaxis de criterios simplificados](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax?v=22.1).`BinaryOperator`

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#create-a-new-view)Crear una nueva vista

Para mostrar el objeto encontrado en una vista de detalles independiente:

1.  Llame al método  [XafApplication.CreateDetailView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.XafApplication.CreateDetailView.overloads?v=22.1)  para crear una vista.
2.  Asigne la vista a la propiedad  [e.ShowViewParameters.CreatedView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ShowViewParameters.CreatedView?v=22.1)  del parámetro de evento.

> PROPINA Puede inicializar la propiedad en el controlador de eventos de cualquier acción de cualquier tipo. Esto le permite mostrar siempre una vista después de ejecutar una acción.`ShowViewParameters.Execute`

Para obtener más información sobre cómo mostrar una vista en una ventana independiente, consulte el tema siguiente:  [Formas de mostrar una vista](https://docs.devexpress.com/eXpressAppFramework/112803/ui-construction/views/ways-to-show-a-view/ways-to-show-a-view?v=22.1).

### [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#manage-an-xaf-application)Administrar una aplicación XAF

El objeto  [XafApplication](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.XafApplication?v=22.1)  es útil cuando necesita crear una vista de lista, una vista detallada, un espacio de objetos, etc. Un usuario puede acceder a un objeto desde muchas ubicaciones en una aplicación XAF. En Controllers, use  [Controller.Application](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Controller.Application?v=22.1)  para obtener dicho acceso.`XafApplication`

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#add-an-action-that-displays-a-pop-up-window-net-6)Agregar una acción que muestra una ventana emergente (.NET 6)

En esta lección se explica cómo crear una acción que muestre una ventana emergente. Este tipo de acción es útil cuando un usuario desea introducir varios parámetros en un cuadro de diálogo emergente antes de ejecutar una acción.

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   Establecer una relación de varios a varios (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402983/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/set-a-many-to-many-relationship-ef-core?v=22.1)))
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)

En este tutorial, implementará la capacidad de agregar notas de una lista predefinida a las descripciones de tareas.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-12)Instrucciones paso a paso

1.  Agregue el objeto de negocio de la  [biblioteca de clase empresarial](https://docs.devexpress.com/eXpressAppFramework/112571/business-model-design-orm/built-in-business-classes-and-interfaces?v=22.1)  a la aplicación. Para ello, agregue el código siguiente a  _MySolution.Module_  |  _Módulo.cs_  archivo:`Note`
    ```csharp
    using DevExpress.Persistent.BaseImpl.EF;
    // ...
    public sealed partial class MySolutionModule : ModuleBase {
        public MySolutionModule() {
            // Adds a business object
            AdditionalExportedTypes.Add(typeof(Note));
        }
        // ...
    }
    ```
2.  Si está trabajando con  **EF Core**, registre el tipo en . Edite el archivo  _BusinessObjects\MySolutionDbContext.cs_  como se muestra a continuación:`Note``DbContext`
    ```csharp
    public class MySolutionEFCoreDbContext : DbContext {
        //...
        public DbSet<Note> Notes { get; set; }
    }
    ```
3.  Si está trabajando con  **EF Core**, agregue una migración y actualice la base de datos. Consulte la siguiente sección para obtener más información:  [Usar un DBMS: Migraciones de configuración](https://docs.devexpress.com/eXpressAppFramework/404144/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/create-a-solution-ef-core?v=22.1#use-a-dbms-setup-migrations).
    
4.  Agregue un nuevo controlador de vistas al proyecto  **MySolution.Module.**  Asígnele  _el nombre PopupNotesController_.
    
5.  En el archivo  _PopupNotesController.cs_, especifique las propiedades del controlador:
    ```csharp
    using DevExpress.ExpressApp;
    using DevExpress.Persistent.BaseImpl.EF;
    // ...
    public partial class PopupNotesController : ViewController {
        // ...
        public PopupNotesController() {
            InitializeComponent();
            //Target the required Views and create their Actions
            TargetObjectType = typeof(DemoTask);
            TargetViewType = ViewType.DetailView;
        }
        // ...
    }
    ```
6.  Agregue la acción y controle su evento:`ShowNotesAction``CustomizePopupWindowParams`
    ```csharp
    public partial class PopupNotesController : ViewController {
        public PopupNotesController() {
            InitializeComponent();
            TargetObjectType = typeof(DemoTask);
            TargetViewType = ViewType.DetailView;
            /*Invoke a pop-up window with a specified View and execute custom code
     when a user clicks the OK or Cancel button*/
            PopupWindowShowAction showNotesAction = new PopupWindowShowAction(this, "ShowNotesAction", PredefinedCategory.Edit) {
                Caption = "Show Notes"
            };
    
            showNotesAction.CustomizePopupWindowParams += ShowNotesAction_CustomizePopupWindowParams;
        }
    
        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Note));
            string noteListViewId = Application.FindLookupListViewId(typeof(Note));
            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(Note), noteListViewId);
            e.View = Application.CreateListView(noteListViewId, collectionSource, true);
        }
        // ...
    }
    ```
    En este paso, controlará el evento  [PopupWindowShowAction.CustomizePopupWindowParams](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.PopupWindowShowAction.CustomizePopupWindowParams?v=22.1)  y establecerá la vista necesaria en el parámetro  [e.View](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventArgs.View?v=22.1)  del controlador. Este código crea la vista de lista de  **notas**  cuando genera la ventana emergente.
    
7.  Controlar el evento de :`ShowNotesAction``Execute`
    ```csharp
    // ...
    public PopupNotesController() {
        // ...
        showNotesAction.Execute += ShowNotesAction_Execute;
    }
    
    private void ShowNotesAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {
        DemoTask task = (DemoTask)View.CurrentObject;
        foreach(Note note in e.PopupWindowViewSelectedObjects) {
            if(!string.IsNullOrEmpty(task.Description)) {
                task.Description += Environment.NewLine;
            }
            // Add selected notes' text to a Task's description
            task.Description += note.Text;
        }
        View.ObjectSpace.CommitChanges();
    }
    ```
    El evento se produce cuando un usuario hace clic en  **Aceptar**  en la ventana emergente. El código del controlador de eventos anexa el valor de la propiedad al valor de la propiedad.`Execute``Note.Text``Task.Description`
    
    El parámetro  [e.PopupWindowViewSelectedObjects](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventArgs.PopupWindowViewSelectedObjects?v=22.1)  del controlador de eventos proporciona un objeto que un usuario selecciona en la ventana emergente.
    
8.  Ejecute la aplicación.
    
    Abra la vista de detalles de un elemento de  **tarea**. La barra de herramientas Vista detallada muestra el botón  **Mostrar notas**. Esta es la acción implementada en esta lección.
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451654-c654db0e-e8e0-495f-afcd-a8a164c6e39f.png)](https://user-images.githubusercontent.com/126447472/254451654-c654db0e-e8e0-495f-afcd-a8a164c6e39f.png)
    
    Haga clic en el botón para abrir la ventana emergente. La ventana emergente muestra una vista de lista para los objetos  **Note**. Cree varios objetos  **Note**.
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451664-9356f45a-a4b7-45f6-ab68-3bde9689d43f.png)](https://user-images.githubusercontent.com/126447472/254451664-9356f45a-a4b7-45f6-ab68-3bde9689d43f.png)
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451684-84903b4b-a29c-45ed-b48f-0b09372a1663.png)](https://user-images.githubusercontent.com/126447472/254451684-84903b4b-a29c-45ed-b48f-0b09372a1663.png)
    
    Seleccione un objeto  **Note**  de la lista y haga clic en  **Aceptar**. Después de eso, el valor de la propiedad  **Task.Description cambia.**
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451832-678076e3-a6d1-4b87-9c59-22ba3524edcb.png)](https://user-images.githubusercontent.com/126447472/254451832-678076e3-a6d1-4b87-9c59-22ba3524edcb.png)
    
    > TIP: Para obtener un ejemplo de cómo crear y mostrar una vista detallada, consulte el tema  [Cómo: Crear y mostrar una vista detallada del objeto seleccionado en una ventana emergente](https://docs.devexpress.com/eXpressAppFramework/118760/ui-construction/ways-to-access-ui-elements-and-their-controls/how-to-create-and-show-a-detail-view-of-the-selected-object-in-a-popup-window?v=22.1)


# Agregar una acción con selección de opciones (.NET 6)

En esta lección se explica cómo crear una acción que admita la selección de opciones.

En esta lección, implementará un nuevo controlador de vista con un archivo . Esta acción permitirá a los usuarios seleccionar valores para las propiedades `SingleChoiceAction`, `Task.Priority` y`Task.Status`.

[![imagen](https://user-images.githubusercontent.com/126447472/254451814-3af3d0dc-8473-43b3-bd8e-e961a360539c.png)](https://user-images.githubusercontent.com/126447472/254451814-3af3d0dc-8473-43b3-bd8e-e961a360539c.png)

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/112737/getting-started/in-depth-tutorial-winforms-webforms/extend-functionality/add-a-simple-action?v=22.1)
> -   [Agregar una acción que muestre una ventana emergente](https://docs.devexpress.com/eXpressAppFramework/112723/getting-started/in-depth-tutorial-winforms-webforms/extend-functionality/add-an-action-that-displays-a-pop-up-window?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-13)Instrucciones paso a paso

1.  Agregue un nuevo controlador de vistas al proyecto  _MySolution.Module._  Asígnele  _el nombre TaskActionsController_.
    
2.  En el archivo  _TaskActionsController.cs_, establezca el :`TargetObjectType`
    ```csharp
    using DevExpress.ExpressApp;
    // ...
    public partial class TaskActionsController : ViewController {
        public TaskActionsController() {
            InitializeComponent();
            TargetObjectType = typeof(DemoTask);
        }
        // ...
    }
    ```
3.  Agregue un y especifique sus propiedades:`SingleChoiceAction`
    ```csharp
    public partial class TaskActionsController : ViewController {
        public TaskActionsController() {
            InitializeComponent();
            TargetObjectType = typeof(DemoTask);
            SingleChoiceAction SetTaskAction = new SingleChoiceAction(this, "SetTaskAction", PredefinedCategory.Edit) {
                Caption = "Set Task",
                //Specify the display mode for the Action's items. Here the items are operations that you perform against selected records.
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                //Set the Action to become available in the Task List View when a user selects one or more objects.
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };
        }
        // ...
    }
    ```
4.  Para rellenar la acción con elementos, rellene la colección  [ChoiceActionBase.Items](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.ChoiceActionBase.Items?v=22.1)  de la acción en el constructor del controlador:
    ``` csharp
    public partial class TaskActionsController : ViewController {
       private ChoiceActionItem setPriorityItem;
       private ChoiceActionItem setStatusItem;
       public TaskActionsController() {
          // ...
          setPriorityItem = 
             new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Priority"), null);
          SetTaskAction.Items.Add(setPriorityItem);
          FillItemWithEnumValues(setPriorityItem, typeof(Priority));
    
          setStatusItem = 
             new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Status"), null);
          SetTaskAction.Items.Add(setStatusItem);
          FillItemWithEnumValues(setStatusItem, typeof(DevExpress.Persistent.Base.General.TaskStatus));
    
       }
       private void FillItemWithEnumValues(ChoiceActionItem parentItem, Type enumType) {
            EnumDescriptor ed = new EnumDescriptor(enumType);
            foreach(object current in ed.Values) {
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                item.ImageName = ImageLoader.Instance.GetEnumValueImageName(current);
                parentItem.Items.Add(item);
            }
        }
    }
    ```
    El ejemplo de código anterior organiza los elementos de la colección Action como un árbol:`Items`
    
    -   El nivel raíz contiene elementos cuyos títulos corresponden a los nombres de las propiedades y. El objeto  [CaptionHelper](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Utils.CaptionHelper?v=22.1)  devuelve títulos de elemento.`DemoTask.Priority``DemoTask.Status`
    -   El nivel anidado contiene los valores y enumeración. El objeto  [EnumDescriptor](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Utils.EnumDescriptor?v=22.1)  devuelve títulos de elementos.`Priority``Status`
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451897-60c0f4db-c66b-46f8-8f28-19f3121b9c16.png)](https://user-images.githubusercontent.com/126447472/254451897-60c0f4db-c66b-46f8-8f28-19f3121b9c16.png)
    
    Al rellenar la colección  [ChoiceActionBase.Items](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.ChoiceActionBase.Items?v=22.1)  en un constructor Controller, como se muestra en el código anterior, puede utilizar  **ActionDesign**  | del  [Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/112830/installation-upgrade-version-history/visual-studio-integration/model-editor?v=22.1).  **Acciones**  |  |  **ChoiceActionItems**  para establecer un nombre de imagen, un acceso directo y un título localizado para los elementos agregados.
    
    Si rellena la colección en un controlador de eventos  [Controller.Activated](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Controller.Activated?v=22.1), el Editor de modelos no carga elementos.`Items`
    
5.  Abra el archivo  _Task.cs_  y asigne imágenes al valor de enumeración como en el ejemplo de código siguiente:`Priority`
    ```csharp
    public enum Priority {
        [ImageName("State_Priority_Low")]
        Low,
        [ImageName("State_Priority_Normal")]
        Normal,
        [ImageName("State_Priority_High")]
        High
    }
    ```
    En este tutorial, los valores de enumeración tienen los atributos  [ImageNameAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ImageNameAttribute?v=22.1)  para establecer imágenes para estos valores en la interfaz de usuario.
    
    XAF se incluye con la biblioteca de imágenes estándar. La biblioteca incluye el `State_Priority_Low`, `State_Priority_Normal` y `State_Priority_High`, y las imágenes utilizadas en esta lección.`
    
6.  Controle el evento  [SingleChoiceAction.Execute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.SingleChoiceAction.Execute?v=22.1)  que se produce cuando un usuario elige el elemento de la acción:
    ```csharp
    public partial class TaskActionsController : ViewController {
        // ...
        public TaskActionsController() {
            // ...
            SetTaskAction.Execute += SetTaskAction_Execute;
        }    
        private void SetTaskAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            /*Create a new ObjectSpace if the Action is used in List View
     Use this ObjectSpace to manipulate the View's selected objects.*/
            IObjectSpace objectSpace = View is ListView ?
                Application.CreateObjectSpace(typeof(DemoTask)) : View.ObjectSpace;
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects);
            if(e.SelectedChoiceActionItem.ParentItem == setPriorityItem) {
                foreach(Object obj in objectsToProcess) {
                    DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                    objInNewObjectSpace.Priority = (Priority)e.SelectedChoiceActionItem.Data;
                }
            } else
                if(e.SelectedChoiceActionItem.ParentItem == setStatusItem) {
                foreach(Object obj in objectsToProcess) {
                    DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                    objInNewObjectSpace.Status = (DevExpress.Persistent.Base.General.TaskStatus)e.SelectedChoiceActionItem.Data;
                }
            }
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
    }    
    ```
    Para obtener acceso a un elemento de acción seleccionado, use el parámetro  [e.SelectedChoiceActionItem](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs.SelectedChoiceActionItem?v=22.1)  del controlador de eventos.
    
    Cree un elemento independiente para editar varios objetos que se muestran actualmente. Este enfoque mejora el rendimiento, ya que cada cambio de objeto no desencadena los eventos del control de cuadrícula.`ObjectSpace`
    
7.  Ejecute la aplicación. Seleccione el elemento  **Tarea**  en el control de navegación. Después de eso, la acción  **Establecer tarea**  se activa.
    
    Para cambiar la propiedad  **Priority**  o  **Status**  de los objetos  **Task**  seleccionados, seleccione un elemento en la lista desplegable Action:
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254451927-3f964770-7678-4129-b0d1-473e0d6c6c68.png)](https://user-images.githubusercontent.com/126447472/254451927-3f964770-7678-4129-b0d1-473e0d6c6c68.png)
    

[![imagen](https://user-images.githubusercontent.com/126447472/254452043-2e0b1a5f-19b6-4e62-aa77-837af1307fde.png)](https://user-images.githubusercontent.com/126447472/254452043-2e0b1a5f-19b6-4e62-aa77-837af1307fde.png)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#add-a-simple-action-using-an-attribute)Agregar una acción simple mediante un atributo

En esta lección se explica cómo utilizar los métodos de un objeto de negocio para agregar una acción simple.

Las instrucciones siguientes muestran cómo agregar un nuevo método con el atributo  [ActionAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.ActionAttribute?v=22.1)  a la clase.`DemoTask`

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   **Establecer una relación de varios a varios**  (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402168/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-many-to-many-relationship-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402983/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/set-a-many-to-many-relationship-ef-core?v=22.1)))
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-14)Instrucciones paso a paso

1.  Agregue el método `Postpone` a la clase `DemoTask`:
    ```csharp
    namespace MySolution.Module.BusinessObjects
    
    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : DevExpress.Persistent.BaseImpl.EF.Task {
        //...
        /*Use this attribute to display the Postpone button in the UI
     and call the Postpone() method when a user clicks this button*/
        [Action(ToolTip = "Postpone the task to the next day")]
        //Shift the task's due date forward by one day
        public void Postpone() {
            if(DueDate == DateTime.MinValue) {
                DueDate = DateTime.Now;
            }
            DueDate = DueDate + TimeSpan.FromDays(1);
        }
    }
    ```
    > PROPINA Puede utilizar el atributo para implementar una acción que pida a un usuario que especifique parámetros en un cuadro de diálogo emergente (por ejemplo, el número de días para posponer una  **tarea**). Consulte el tema siguiente para obtener un ejemplo:  [Cómo: Crear una acción mediante el atributo action](https://docs.devexpress.com/eXpressAppFramework/112619/ui-construction/controllers-and-actions/actions/how-to-create-an-action-using-the-action-attribute?v=22.1).`Action`
    
2.  Muestre la columna  **Fecha de vencimiento**  en la Vista Lista de  **tareas**. Abra  **MySolution.Module**  |  **Archivo ModelDesignedDiffs.xafml.**  En el Editor de modelos, haga lo siguiente:
    
    -   Ir a  **Vistas | MySolution.Module.BusinessObjects | DemoTask | DemoTask_ListView | Columnas**.
        
    -   Haga clic con el botón secundario en el encabezado de cuadrícula y haga clic en el elemento  **Selector de columnas**.
        
    -   Arrastre la columna  **Fecha de vencimiento**  a la vista y guarde el archivo  **ModelDesignedDiffs.xafml.**
        
        [![Tutorial de Blazor mostrar columna listview](https://camo.githubusercontent.com/a85e46865fdb4cc963b5762667e8283f838ff88fb8a6e7a5f25d16d26f056c0c/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f626c617a6f722d7475746f7269616c2d6174747269627574652d616374696f6e2d646973706c6179636f6c756d6e2e6769663f763d32322e31)](https://camo.githubusercontent.com/a85e46865fdb4cc963b5762667e8283f838ff88fb8a6e7a5f25d16d26f056c0c/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f626c617a6f722d7475746f7269616c2d6174747269627574652d616374696f6e2d646973706c6179636f6c756d6e2e6769663f763d32322e31)
        
3.  Ejecute la aplicación. Seleccione el elemento  **Tarea**  en el control de navegación.
    
    Seleccione una o más tareas en la Vista Lista de  **tareas**. Aparecerá el botón  **Posponer**  acción. Haga clic en este botón. La fecha de vencimiento de las tareas seleccionadas se adelanta un día.
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#access-the-settings-of-a-property-editor-in-a-detail-view)Acceder a la configuración de un editor de propiedades en una vista detallada

En esta lección se explica cómo acceder a los editores en una  [vista detallada](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1)  y cambiar su configuración.

Las instrucciones siguientes muestran cómo hacer que el editor de propiedades  **Cumpleaños**  muestre un selector de fecha desplazable en su ventana desplegable.

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   **Heredar de la clase de biblioteca de clase empresarial**  (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-15)Instrucciones paso a paso

1.  En el proyecto  **MySolution.Blazor.Server**, agregue un controlador de View a la carpeta  _Controllers_. Asigne al nuevo controlador el nombre "_DateEditCalendarController_". Especifique la clase antecesora del controlador  [ObjectViewController<ViewType, ObjectType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ObjectViewController-2?v=22.1):
    ```csharp
    using DevExpress.ExpressApp;
    // ...
    
    public partial class DateEditCalendarController : ObjectViewController<DetailView, Contact> {
        public DateEditCalendarController() {
            InitializeComponent();
        }
        // ...
    }
    ```
    El hereda de la clase base  [ObjectViewController<ViewType, ObjectType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ObjectViewController-2?v=22.1). Los parámetros de la clase base habilitan el controlador solo para vistas detalladas que muestran y editan objetos.`DateEditCalendarController`
    
2.  Anule el método. Utilice el método  [DetailViewExtensions.CustomizeViewItemControl](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DetailViewExtensions.CustomizeViewItemControl--1(DevExpress.ExpressApp.DetailView-DevExpress.ExpressApp.Controller-System.Action---0--System.String--)?v=22.1)  para tener acceso a la configuración del editor de propiedades:`OnActivated``Birthday`
    ```csharp
    namespace MySolution.Blazor.Server.Controllers {
        public partial class DateEditCalendarController : ObjectViewController<DetailView, Contact> {
            public DateEditCalendarController() {
                InitializeComponent();
            }
            protected override void OnActivated() {
                base.OnActivated();
                //Access the Birthday property editor settings
                View.CustomizeViewItemControl<DateTimePropertyEditor>(this, SetCalendarView, nameof(Contact.Birthday));
            }
            private void SetCalendarView(DateTimePropertyEditor propertyEditor) {
                //Obtain the Component Adapter
                var dateEditAdapter = (DxDateEditAdapter)propertyEditor.Control;
                //Set the date picker display mode to scroll picker
                dateEditAdapter.ComponentModel.PickerDisplayMode = DevExpress.Blazor.DatePickerDisplayMode.ScrollPicker;
            }
        }
    }
    ```
    Utilice la propiedad  **Adaptador de componentes**  para tener acceso a las  [propiedades ASP.NET reales del componente Core Blazor.](https://docs.devexpress.com/eXpressAppFramework/113536/business-model-design-orm/data-types-supported-by-built-in-editors/date-and-time-properties?v=22.1#aspnet-core-blazor)`ComponentModel`
    
    Para obtener información general sobre la arquitectura del Editor de propiedades y los controles de interfaz de usuario usados por XAF, revise los siguientes artículos:
    
    -   [Implementar un editor de propiedades basado en un componente personalizado (Blazor)](https://docs.devexpress.com/eXpressAppFramework/402189/ui-construction/view-items-and-property-editors/property-editors/implement-a-property-editor-based-on-custom-components-blazor?v=22.1)
    -   [Tipos de datos compatibles con editores integrados](https://docs.devexpress.com/eXpressAppFramework/113014/business-model-design-orm/data-types-supported-by-built-in-editors?v=22.1)
3.  Ejecute la aplicación y abra la Vista de detalles de  **contacto**. El editor de  **cumpleaños**  muestra un selector de fecha desplazable en su ventana desplegable:
    
    [![imagen](https://user-images.githubusercontent.com/126447472/254452105-fdca1ad4-e231-41ea-b802-98ca7dec104f.png)](https://user-images.githubusercontent.com/126447472/254452105-fdca1ad4-e231-41ea-b802-98ca7dec104f.png)


# Obtener acceso al componente de cuadrícula en una vista de lista (.NET 6)

En esta lección se explica cómo tener acceso a las propiedades de un componente de cuadrícula que se muestra en una vista de lista.

Las instrucciones siguientes describen la implementación de un nuevo controlador de vista. Este controlador permite que las operaciones cambien el tamaño de las columnas.

> NOTA Antes de continuar, tómese un momento para repasar la siguiente lección:
> 
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-16)Instrucciones paso a paso

1.  En el proyecto  **MySolution.Blazor.Server**, agregue un controlador de View a la carpeta  _Controllers_. Asigne a este controlador  _el nombre ColumnResizeModeViewController_.
    
2.  Especifique la clase antecesora del controlador y reemplace el método:`ViewController<ListView>` `OnViewControlsCreated`
    ```csharp
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Blazor.Editors;
    
    namespace MySolution.Blazor.Server.Controllers {
        public partial class ColumnResizeModeViewController : ViewController<ListView> {
            public ColumnResizeModeViewController() {
                InitializeComponent();
            }
            // ...
            protected override void OnViewControlsCreated() {
                base.OnViewControlsCreated();
                if (View.Editor is DxGridListEditor gridListEditor) {
                    //Obtain the Component Adapter
                    IDxGridAdapter dataGridAdapter = gridListEditor.GetGridAdapter();
                    //Access grid component properties and specify how exactly a user can resize columns
                    dataGridAdapter.GridModel.ColumnResizeMode = DevExpress.Blazor.GridColumnResizeMode.ColumnsContainer;
                }
            }
            // ...
        }
    }
    ```
3.  Ejecute la aplicación. Intente cambiar el tamaño de una columna en un componente de cuadrícula en cualquier vista de lista. El ancho del contenedor de cuadrícula cambia, mientras que las otras columnas conservan su ancho.
    
![image](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial/assets/126447472/bb8f6511-ecd3-4596-9e1f-616846a014f2)

    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#ui-customization)Personalización de la interfaz de usuario

En esta sección del tutorial se explica cómo personalizar la interfaz de usuario generada automáticamente.

Los elementos visuales de la aplicación XAF se basan en las clases de datos que se declaran y en la información de los ensamblados a los que hace referencia la aplicación. Toda la información recibida son metadatos: datos que definen la estructura de la base de datos y las características de la aplicación en un formato neutral que puede adoptar para cualquier plataforma de destino. Estos metadatos se denominan  [modelo de aplicación](https://docs.devexpress.com/eXpressAppFramework/112579/ui-construction/application-model-ui-settings-storage?v=22.1). Es una herramienta poderosa que le permite realizar cambios en su aplicación.

Para personalizar el  **modelo de aplicación**  en tiempo de diseño, utilice el  [Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Se abre directamente desde Visual Studio.

Las siguientes lecciones explican cómo usar el  **Editor de modelos**:

-   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)
-   [Especificar la configuración de la acción](https://docs.devexpress.com/eXpressAppFramework/402146/getting-started/in-depth-tutorial-blazor/ui-customization/specify-action-settings?v=22.1)
-   [Dar formato a un título de objeto de negocio](https://docs.devexpress.com/eXpressAppFramework/402140/getting-started/in-depth-tutorial-blazor/ui-customization/format-a-business-object-caption?v=22.1)
-   [Crear una propiedad calculada](https://docs.devexpress.com/eXpressAppFramework/402144/getting-started/in-depth-tutorial-blazor/ui-customization/create-calculated-property?v=22.1)
-   [Dar formato a un valor de propiedad](https://docs.devexpress.com/eXpressAppFramework/402141/getting-started/in-depth-tutorial-blazor/ui-customization/format-a-property-value?v=22.1)
-   [Usar un editor multilínea para las propiedades de cadena](https://docs.devexpress.com/eXpressAppFramework/402147/getting-started/in-depth-tutorial-blazor/ui-customization/use-a-multiline-editor-for-string-properties?v=22.1)
-   [Agregar un elemento al control de navegación](https://docs.devexpress.com/eXpressAppFramework/402131/getting-started/in-depth-tutorial-blazor/ui-customization/add-an-item-to-the-navigation-control?v=22.1)
-   [Implementar la validación del valor de la propiedad en el modelo de aplicación](https://docs.devexpress.com/eXpressAppFramework/402142/getting-started/in-depth-tutorial-blazor/ui-customization/implement-property-value-validation-in-the-application-model?v=22.1)
-   [Personalizar el diseño Ver elementos](https://docs.devexpress.com/eXpressAppFramework/402137/getting-started/in-depth-tutorial-blazor/ui-customization/customize-the-view-items-layout?v=22.1)
-   [Localizar elementos de la interfaz de usuario](https://docs.devexpress.com/eXpressAppFramework/403184/getting-started/in-depth-tutorial-blazor/ui-customization/localize-ui-elements?v=22.1)
-   [Agregar un editor a una vista de detalles](https://docs.devexpress.com/eXpressAppFramework/403217/getting-started/in-depth-tutorial-blazor/ui-customization/add-an-editor-to-a-detail-view?v=22.1)
-   [Cambiar la visibilidad de campo en una vista de lista](https://docs.devexpress.com/eXpressAppFramework/403230/getting-started/in-depth-tutorial-blazor/ui-customization/change-field-visibility-in-a-list-view?v=22.1)
-   [Filtrar vistas de lista](https://docs.devexpress.com/eXpressAppFramework/403238/getting-started/in-depth-tutorial-blazor/ui-customization/change-list-view-filters?v=22.1)
-   [Lista de grupos Ver datos](https://docs.devexpress.com/eXpressAppFramework/403248/getting-started/in-depth-tutorial-blazor/ui-customization/group-list-view-data?v=22.1)

Si la opción requerida no está disponible en el Editor de modelos, puede acceder directamente a las opciones de los controles utilizados en la aplicación. Revise los siguientes temas para obtener más información:

-   [Configuración del editor de acceso](https://docs.devexpress.com/eXpressAppFramework/402153/getting-started/in-depth-tutorial-blazor/extend-functionality/access-editor-settings?v=22.1)
-   [Configuración de componentes de cuadrícula de vista de lista de acceso mediante un controlador](https://docs.devexpress.com/eXpressAppFramework/402154/getting-started/in-depth-tutorial-blazor/extend-functionality/access-data-grid-settings?v=22.1)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#place-an-action-in-a-different-location)Colocar una acción en una ubicación diferente

En esta lección se explica cómo mover una  [acción](https://docs.devexpress.com/eXpressAppFramework/112622/ui-construction/controllers-and-actions/actions?v=22.1)  a un  [contenedor de acciones](https://docs.devexpress.com/eXpressAppFramework/112610/ui-construction/action-containers?v=22.1)  diferente.

Un contenedor de acciones es un control que muestra una acción o un conjunto de acciones.

Las instrucciones siguientes explican cómo mover el del contenedor de acción de  **vista**  al contenedor de  **acción de edición**.`ClearTasksAction`

[![image](https://user-images.githubusercontent.com/126447472/254452149-db05d3a4-f825-4fa2-b32f-c032a821b7b8.png)](https://user-images.githubusercontent.com/126447472/254452149-db05d3a4-f825-4fa2-b32f-c032a821b7b8.png)

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)
> -   [Agregar una acción que muestre una ventana emergente](https://docs.devexpress.com/eXpressAppFramework/402158/getting-started/in-depth-tutorial-blazor/extend-functionality/add-an-action-that-displays-a-pop-up-window?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-17)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  En el  **Editor de modelos**, vaya a  **ActionDesign**  |  **Nodo ActionToContainerMapping**. Expanda el nodo Vista que es el contenedor  de acciones de  **Vista**. Arrastre el nodo secundario  **ClearTasksAction**  al nodo  **Editar**.  **Establezca el índice**  del nodo en .`0`
    
    [![image](https://user-images.githubusercontent.com/126447472/254452353-c21d4f75-6b86-48a9-b1da-c329eb3ceab7.png)](https://user-images.githubusercontent.com/126447472/254452353-c21d4f75-6b86-48a9-b1da-c329eb3ceab7.png)
    
    Los nodos secundarios del nodo  **ActionToContainerMapping**  corresponden a los contenedores de acciones de la aplicación. Las acciones se asignan a contenedores de acciones según los valores de la propiedad  [Category](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.ActionBase.Category?v=22.1).
    
    Cuando definió el en la lección  [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1), estableció la propiedad  [Category](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Actions.ActionBase.Category?v=22.1)  en . es un valor de la enumeración que corresponde al contenedor de acciones  **de vista**.`ClearTasksAction``View``View``DevExpress.Persistent.Base.PredefinedCategory`
    
3.  Ejecute la aplicación. En la vista Detalles del  **contacto**, el botón  **Borrar tarea**  aparece a la izquierda del botón  **Eliminar**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254452500-234cd428-8bb5-477d-b846-534476a11baa.png)](https://user-images.githubusercontent.com/126447472/254452500-234cd428-8bb5-477d-b846-534476a11baa.png)
    

> PROPINA Puede controlar el evento  [ActionControlsSiteController.CustomizeContainerActions](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ActionControlsSiteController.CustomizeContainerActions?v=22.1)  para cambiar la ubicación de una acción en el código.

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#specify-action-settings)Especificar la configuración de la acción

En esta lección se explica cómo modificar las propiedades de Action.

Las instrucciones siguientes explican cómo cambiar la información sobre herramientas y el mensaje de confirmación de  **ClearTasksAction**. Esta acción se definió en la lección  [Agregar una acción sencilla](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1).

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   [Agregar una acción simple](https://docs.devexpress.com/eXpressAppFramework/402157/getting-started/in-depth-tutorial-blazor/extend-functionality/add-a-simple-action?v=22.1)
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-18)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  En el  **Editor de modelos**, vaya a  **ActionDesign**  |  **Nodo Acciones**. Cambie los valores de propiedad del nodo  **ClearTasksAction**  de la siguiente manera:
    
    -   Establezca la propiedad  **Información sobre herramientas**  en .`Clear the current Contact's tasks`
    -   Establezca la propiedad  **ConfirmationMessage**  en .`Are you sure you want to clear all the tasks?`
3.  Ejecute la aplicación y abra la Vista de detalles de  **contacto**. Desplace el puntero del mouse sobre el botón  **Borrar tareas**  para ver la información sobre herramientas.
    
    [![image](https://user-images.githubusercontent.com/126447472/254452567-884e74b9-b14b-4cee-a95b-2d9c68eabe15.png)](https://user-images.githubusercontent.com/126447472/254452567-884e74b9-b14b-4cee-a95b-2d9c68eabe15.png)
    
4.  Haga clic en el botón para mostrar el mensaje de confirmación.
    
    [![image](https://user-images.githubusercontent.com/126447472/254452583-df4821b0-9667-4352-a2a7-5ccb2b04eab5.png)](https://user-images.githubusercontent.com/126447472/254452583-df4821b0-9667-4352-a2a7-5ccb2b04eab5.png)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#format-a-business-object-caption)Dar formato a un título de objeto de negocio

En esta lección se explica cómo dar formato a un título del formulario de detalles de un objeto de negocio.

[![image](https://user-images.githubusercontent.com/126447472/254452592-2c8c36d2-ed5e-4aaf-a5da-0c8ddc77e409.png)](https://user-images.githubusercontent.com/126447472/254452592-2c8c36d2-ed5e-4aaf-a5da-0c8ddc77e409.png)

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   Heredar de la clase de biblioteca de clase empresarial (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-19)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
2.  En el  **Editor de modelos**, desplácese hasta  **BOModel**  |  **Nodo MySolution.Module.BusinessObjects.**  Seleccione el nodo  **Contacto**.
3.  Establezca el valor de la propiedad  **ObjectCaptionFormat**  en las propiedades de clase que se muestran a la derecha.`{0:FullName} from {0:Department}`

[![image](https://user-images.githubusercontent.com/126447472/254452619-bc1335ae-47f3-4406-8022-3fdf2a287dd9.png)](https://user-images.githubusercontent.com/126447472/254452619-bc1335ae-47f3-4406-8022-3fdf2a287dd9.png)

4.  Ejecute la aplicación. Abra el formulario de detalles de un objeto  **Contact**. Ahora puedes ver el título personalizado:

[![image](https://user-images.githubusercontent.com/126447472/254452635-f899ed04-5cc0-4b7c-b1e0-fcb06c050dd7.png)](https://user-images.githubusercontent.com/126447472/254452635-f899ed04-5cc0-4b7c-b1e0-fcb06c050dd7.png)

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#create-a-calculated-property)Crear una propiedad calculada

En esta lección se explica cómo crear propiedades calculadas.

Las instrucciones siguientes explican cómo agregar una clase  **Payment**  con las siguientes propiedades:

-   **Tasa**  (una propiedad persistente)
-   **Horas**  (una propiedad persistente)
-   **Importe**  (una propiedad calculada  [no persistente](https://docs.devexpress.com/eXpressAppFramework/116516/business-model-design-orm/non-persistent-objects?v=22.1): `Amount = Rate * Hours`)

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   **Heredar de la clase de biblioteca de clase empresarial**  (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/112741/getting-started/in-depth-tutorial-winforms-webforms/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-20)Instrucciones paso a paso

1.  Cree un objeto de negocio en el proyecto  _MySolution.Module._`Payment`
    
2.  Reemplace la declaración de clase generada por el código siguiente:
    ```csharp
    using DevExpress.Persistent.Base;
    using DevExpress.Persistent.BaseImpl;
    using DevExpress.Xpo;
    // ...
    [DefaultClassOptions]
    public class Payment : BaseObject {
        public Payment(Session session) : base(session) { }
        private double rate;
        public double Rate {
            get {
                return rate;
            }
            set {
                if(SetPropertyValue(nameof(Rate), ref rate, value))
                    OnChanged(nameof(Amount));
            }
        }
        private double hours;
        public double Hours {
            get {
                return hours;
            }
            set {
                if(SetPropertyValue(nameof(Hours), ref hours, value))
                    OnChanged(nameof(Amount));
            }
        }
        /*Use this attribute to specify that the value of this property depends on the values of other fields.
     The expression that you pass as a parameter calculates the property value.*/
        [PersistentAlias("Rate * Hours")]
        public double Amount {
            get { return (double)(EvaluateAlias(nameof(Amount)) ?? 0); }
        }
    }
    ```
    La propiedad no tiene descriptor de acceso. Su cálculo del valor tiene lugar en el descriptor de acceso.`Amount``set``get`
    
3.  Para aplicaciones basadas en EF Core, registre el tipo `Payment` en el `DbContext` :
    ```csharp
    public class MySolutionEFCoreDbContext : DbContext {
        //...
        public DbSet<Payment> Payments { get; set; }
    }
    ```
4.  Para aplicaciones basadas en EF Core, agregue una migración y actualice la base de datos. Consulte la siguiente sección para obtener más información:  [Usar un DBMS: Migraciones de configuración](https://docs.devexpress.com/eXpressAppFramework/404144/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/create-a-solution-ef-core?v=22.1#use-a-dbms-setup-migrations).
    
5.  Ejecute la aplicación. Seleccione el elemento de pago en el control  **de**  navegación y haga clic en "Nuevo". En la vista Detalles de pago, cambie las propiedades  **Tarifa**  y  **Horas**  para ver cómo afecta esto  **a la propiedad**  **Importe**.
    

[![image](https://user-images.githubusercontent.com/126447472/254452664-4ea6c08c-9c8b-493f-8988-aa98c5304182.png)](https://user-images.githubusercontent.com/126447472/254452664-4ea6c08c-9c8b-493f-8988-aa98c5304182.png)


# Dar formato a un valor de propiedad

En esta lección se explica cómo dar formato a una propiedad de clase empresarial y especificar su configuración de  [máscara de entrada](https://docs.devexpress.com/WindowsForms/583/controls-and-libraries/editors-and-simple-controls/common-editor-features-and-concepts/input-mask?v=22.1).

En esta lección, personalizará el formato de presentación para el `Task.StartDate` `Task.DueDate` `Task.PercentCompleted`, y las propiedades en el  [Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   Heredar de la clase de biblioteca de clase empresarial (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-21)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  Vaya a la  **lista de materiales**  |  **DevExpress.Persistent.BaseImpl.EF**  |  **Tarea**  |  **Nodo OwnMembers**.
    
3.  Para los nodos secundarios  **DueDate**  y  **StartDate**, establezca el valor de la propiedad  [DisplayFormat](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.PropertyEditor.DisplayFormat?v=22.1)  en - un patrón de fecha largo.`D`
    
    [![image](https://user-images.githubusercontent.com/126447472/254452686-2a5b8d65-6bdd-49a3-90fd-e160d1fde644.png)](https://user-images.githubusercontent.com/126447472/254452686-2a5b8d65-6bdd-49a3-90fd-e160d1fde644.png)
    
    Tenga en cuenta que el valor de la propiedad  **EditMask**  es - un patrón de día corto.`d`
    
4.  Para el nodo secundario  **PercentCompleted**, establezca la propiedad  **DisplayFormat**  en .`{0:N0}%`
    

[![image](https://user-images.githubusercontent.com/126447472/254452804-28600895-28f3-488c-8108-73f21e71f60a.png)](https://user-images.githubusercontent.com/126447472/254452804-28600895-28f3-488c-8108-73f21e71f60a.png)

5.  Ejecute la aplicación. Invoque una lista de detalles para la clase  **DemoTask**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254452818-acdddb78-85b7-498c-8b57-edab09c05e8a.png)](https://user-images.githubusercontent.com/126447472/254452818-acdddb78-85b7-498c-8b57-edab09c05e8a.png)
    
    Note how text format changes when  **StartDate**  and  **DueDate**  editors receive or lose focus. If you focus an editor, its  **EditMask**  takes effect (  - short date pattern). If an editor loses input focus, its  **DisplayFormat**  takes over (  - long date pattern).`d``D`
    
    The  **PercentCompleted**  display text includes the percentage sign: ‘%’.
    

> NOTE In .NET 5, the libraries used for globalization functionality has been changed. Refer to the following topic for details:  [Globalization APIs use ICU libraries on Windows](https://docs.microsoft.com/en-us/dotnet/core/compatibility/globalization/5.0/icu-globalization-api). If a current thread’s culture is set to a culture that includes only the language and not the country (for example, “de” or “en”), the currency symbol renders as an international currency symbol (), for example:  . Refer to the following topics for details:`¤``100,00 ¤`
> 
> -   [ICU Localization - Currency symbol](https://docs.microsoft.com/en-us/dotnet/core/compatibility/globalization/5.0/icu-globalization-api#currency-symbol).
> -   [CurrencySymbol](https://docs.microsoft.com/dotnet/api/system.globalization.numberformatinfo.currencysymbol#System_Globalization_NumberFormatInfo_CurrencySymbol).

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#use-a-multiline-editor-for-string-properties)Use a Multiline Editor for String Properties

This lesson explains how to display a multiline editor for string properties.

The instructions below explain how to enable a multiline text box for the  **Web Page Address**  property editor in the  **Contact**  Detail View.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-22)Step-by-Step Instructions

1.  Open the  _Model.DesignedDiffs.xafml_  file in the  [Model Editor](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  Navigate to the  **BOModel**  |  **MySolutuon.Module.BusinessObjects**  |  **Contact**  |  **OwnMembers**  node.
    
3.  For the  **WebPageAddress**  child node, set the properties as follows:
    
    -   Set the  **RowCount**  property to  .`2`
        
        This creates a two-line editor for the  **WebPageAddress**  property.
        
    -   Set the  **Size**  property to  .`100`
        
        This allows a user to enter up to 100 symbols.
        
        You can also apply the  [FieldSize](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DC.FieldSizeAttribute?v=22.1)  attribute in code.
        
    
    [![XAF ASP.NET Core Blazor multiline text box](https://camo.githubusercontent.com/84570efe8c3fbc2b7525b6e350b53270b1ad6fff5aa1f9816dd2ea3587cae4a6/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f7475746f7269616c5f7569635f6d756c74696c696e655f74657874656469742e706e673f763d32322e31)](https://camo.githubusercontent.com/84570efe8c3fbc2b7525b6e350b53270b1ad6fff5aa1f9816dd2ea3587cae4a6/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f7475746f7269616c5f7569635f6d756c74696c696e655f74657874656469742e706e673f763d32322e31)
    
4.  Ejecute la aplicación. Abra una lista de detalles para un objeto  **Contact**. La propiedad  **Dirección de página Web**  utiliza un editor de cuadros de texto de dos líneas.
    
    [![XAF ASP.NET Core Blazor multiline text box](https://camo.githubusercontent.com/2147c09d5f2d2e4f76f85c5209aafd253285de659c061b8a8e079fb6298fe8c6/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f626c617a6f725f7475746f7269616c5f7569635f6d756c74696c696e655f746578742e706e673f763d32322e31)](https://camo.githubusercontent.com/2147c09d5f2d2e4f76f85c5209aafd253285de659c061b8a8e079fb6298fe8c6/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f626c617a6f725f7475746f7269616c5f7569635f6d756c74696c696e655f746578742e706e673f763d32322e31)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#add-an-item-to-the-navigation-control)Agregar un elemento al control de navegación

En esta lección se explica cómo agregar un elemento al control de navegación.

Las instrucciones siguientes describen cómo agregar el elemento  **Notas**  al control de navegación. Cuando un usuario hace clic en este elemento, la aplicación muestra una vista de lista para la clase empresarial  **Note**  agregada en la lección siguiente:  [Agregar una acción que muestre una ventana emergente](https://docs.devexpress.com/eXpressAppFramework/402158/getting-started/in-depth-tutorial-blazor/extend-functionality/add-an-action-that-displays-a-pop-up-window?v=22.1).

[![image](https://user-images.githubusercontent.com/126447472/254452928-3131bafd-64af-4320-a26d-d68f90d4a020.png)](https://user-images.githubusercontent.com/126447472/254452928-3131bafd-64af-4320-a26d-d68f90d4a020.png)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-23)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). En la vista de árbol, navegue hasta  **NavigationItems**  |  **Artículos**  |  **Predeterminado**  |  **Nodo Elementos**. Para agregar un elemento secundario a un elemento de navegación, haga clic con el botón secundario en el nodo  **Elementos**  y seleccione  **Agregar...**  |  **NavigationItem**  en el menú contextual:
    
    [![image](https://user-images.githubusercontent.com/126447472/254452964-a062d659-ec87-4aa6-905b-2c2a7f153243.png)](https://user-images.githubusercontent.com/126447472/254452964-a062d659-ec87-4aa6-905b-2c2a7f153243.png)
    
2.  Especifique las siguientes propiedades para el nuevo elemento:
    
    -   Establezca la propiedad  **View**  en .`Note_ListView`
    -   Establezca la propiedad  **Caption**  en .`Notes`
    -   Establezca la propiedad  **Id**  en .`Note`
    
    [![image](https://user-images.githubusercontent.com/126447472/254452981-917b083f-d3cf-4b03-adec-6af0721ddcec.png)](https://user-images.githubusercontent.com/126447472/254452981-917b083f-d3cf-4b03-adec-6af0721ddcec.png)
    
3.  Ejecute la aplicación. Puede ver el nuevo elemento de navegación que le permite agregar y editar notas de texto sin formato.
    
    [![image](https://user-images.githubusercontent.com/126447472/254452996-84f18b78-6dd4-40cc-aafa-7821cf6b6044.png)](https://user-images.githubusercontent.com/126447472/254452996-84f18b78-6dd4-40cc-aafa-7821cf6b6044.png)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#implement-property-value-validation-in-the-application-model)Implementar la validación del valor de la propiedad en el modelo de aplicación

En esta lección se explica cómo comprobar si el valor de una propiedad cumple unos criterios predefinidos. Esta funcionalidad estará disponible si instala el  **módulo de validación**.

Las instrucciones siguientes explican cómo evitar que un usuario marque una tarea como completada antes de que la tarea haya comenzado ( es ).`DemoTask.Status` `NotStarted`

> NOTA Antes de continuar, tómese un momento para repasar la siguiente lección:
> 
> -   Implementar la validación del valor de la propiedad en el código (núcleo  [de XPO/](https://docs.devexpress.com/eXpressAppFramework/402165/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-property-value-validation-in-code-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402980/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/implement-property-value-validation-in-code-ef-core?v=22.1)))

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-24)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Vaya a la  **Validación**  |  **Nodo Reglas**. Agregar una nueva regla de validación: haga clic con el botón derecho en el nodo  **Reglas**  y seleccione  **Agregar...**  |  **RuleCriteria**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453031-f7c51984-42da-499e-a125-c6ac63985f4d.png)](https://user-images.githubusercontent.com/126447472/254453031-f7c51984-42da-499e-a125-c6ac63985f4d.png)
    
2.  Establezca los valores de las siguientes propiedades para el nodo:
    
    -   **TargetType**  a "MySolution.Module.BusinessObjects.DemoTask"
    -   **Criterios**  para `Status != 'NotStarted'`
    -   **ID**  a `TaskStarted`
    -   **TargetContextIDs**  a `MarkCompleted`
    -   **CustomMessageTemplate**  para `Cannot set the task as completed because it has not started.`
    
    [![image](https://user-images.githubusercontent.com/126447472/254453050-5aa88f53-3657-4a53-b01a-217ab2450910.png)](https://user-images.githubusercontent.com/126447472/254453050-5aa88f53-3657-4a53-b01a-217ab2450910.png)
    
    El  valor de la propiedad Criteria debe respetar la  [sintaxis del lenguaje Criteria](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax?v=22.1). Para definir los criterios, haga clic en el botón de puntos suspensivos ([![EllipsisButton](https://camo.githubusercontent.com/2ba2ee67a57b7dcbfd265715bf94f4bda1e01aa2f93fefc791fba5c403cd0bc0/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f656c6c6970736973627574746f6e3131363138322e706e673f763d32322e31)](https://camo.githubusercontent.com/2ba2ee67a57b7dcbfd265715bf94f4bda1e01aa2f93fefc791fba5c403cd0bc0/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f656c6c6970736973627574746f6e3131363138322e706e673f763d32322e31)) situado a la derecha del valor  **Criterios**  e invoque el cuadro de diálogo  **Generador de filtros**. En este cuadro de diálogo, puede diseñar visualmente una expresión de criterio.
    
3.  En el  **ActionDesign**  |  **Acciones**  |  **Task.MarkCompleted**, establezca la propiedad  **ValidationContexts**  en .`MarkCompleted`
    
    [![image](https://user-images.githubusercontent.com/126447472/254453069-0af8cd3b-0ef6-46ba-a772-01a15fde9352.png)](https://user-images.githubusercontent.com/126447472/254453069-0af8cd3b-0ef6-46ba-a772-01a15fde9352.png)
    
    > PROPINA Puede utilizar los contextos  **Guardar**  o  **Eliminar**. La validación de reglas con estos contextos se produce cuando un usuario guarda o elimina un objeto (consulte  [Reglas de validación](https://docs.devexpress.com/eXpressAppFramework/113008/validation/validation-rules?v=22.1)).
    
4.  Cambie el título de la acción  **MarkCompleted**  a .`Mark Completed`
    
5.  Ejecute la aplicación. Asigne el valor "Not Started" a la propiedad  **Status**  de uno de los objetos  **DemoTask**  existentes. Haga clic en el botón  **Marcar completado**. Aparece el siguiente cuadro de diálogo  **Error de validación**:
    
    [![image](https://user-images.githubusercontent.com/126447472/254453117-77a0e858-6e6d-4827-962b-3280028e0d3d.png)](https://user-images.githubusercontent.com/126447472/254453117-77a0e858-6e6d-4827-962b-3280028e0d3d.png)
    

También puede agregar una regla a una clase o propiedad en el código. Para obtener información adicional, consulte el tema siguiente:  [Implementar la validación del valor de la propiedad en el código (XPO).](https://docs.devexpress.com/eXpressAppFramework/402165/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-property-value-validation-in-code-xpo?v=22.1)

En el tema siguiente se enumeran todos los tipos de reglas disponibles y sus descripciones:  [Reglas de validación](https://docs.devexpress.com/eXpressAppFramework/113008/validation/validation-rules?v=22.1).

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#customize-the-view-items-layout)Personalizar el diseño Ver elementos

En esta lección se explica cómo personalizar el diseño predeterminado del editor en una vista de detalles. Las instrucciones siguientes utilizan la vista de detalles de contacto como ejemplo.

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-25)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  Navegar a las  **vistas**  |  **MySolution.Module.BusinessObjects**  |  **Contacto**  |  **Contact_DetailView**  |  **Nodo de diseño**.
    
3.  El Editor de modelos muestra una superficie de diseño que imita la vista Detalles de contacto. Para cambiar el diseño del editor, haga clic con el botón derecho en el espacio vacío de la vista y elija  **Personalizar diseño**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453090-ce3cbbae-254a-4a60-8674-2ba48cb8f0eb.png)](https://user-images.githubusercontent.com/126447472/254453090-ce3cbbae-254a-4a60-8674-2ba48cb8f0eb.png)
    
    El formulario  **Personalización**  le permite agregar, quitar y reordenar elementos.
    
    -   Para quitar un elemento, arrástrelo desde la Vista de detalles al  **formulario de personalización**.
        
    -   Para agregar un elemento, arrástrelo desde el  **formulario de personalización**  a la  **vista de detalles**.
        
    -   Para reordenar los elementos, arrastre los editores para crear un nuevo diseño y guardar los cambios.
        
        [![image](https://user-images.githubusercontent.com/126447472/254453143-593cca75-88a3-484c-8ffd-b1739b4edb1a.png)](https://user-images.githubusercontent.com/126447472/254453143-593cca75-88a3-484c-8ffd-b1739b4edb1a.png)
        
    
    Para obtener más información sobre el formulario  **Personalización**  y la ficha  **Vista de árbol de diseño**  y su menú contextual, consulte el tema Personalización predeterminada en  [tiempo de ejecución](https://docs.devexpress.com/WindowsForms/2307/controls-and-libraries/form-layout-managers/layout-and-data-layout-controls/design-time-and-runtime-customization/default-runtime-customization?v=22.1).
    
4.  Explore las opciones adicionales de personalización de diseño disponibles en el menú contextual. Haga clic en la ficha  **Vista de árbol de diseño**  del  **formulario de personalización**. Haga clic con el botón secundario en un nodo de árbol para invocar un menú contextual.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453156-3671b596-80d3-4972-a269-775be9cbc9ab.png)](https://user-images.githubusercontent.com/126447472/254453156-3671b596-80d3-4972-a269-775be9cbc9ab.png)
    
5.  Ejecute la aplicación para ver el nuevo diseño de la vista de detalles de  **contacto**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453168-760f6b00-d589-4f0b-9b05-6365ebd931fd.png)](https://user-images.githubusercontent.com/126447472/254453168-760f6b00-d589-4f0b-9b05-6365ebd931fd.png)
    

> PROPINA Para restablecer los cambios realizados en el diseño, haga clic con el botón derecho en  **Contact_DetailView**  |  **Diseño**  y elija  **Restablecer diferencias**.

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#localize-ui-elements)Localizar elementos de la interfaz de usuario

En esta lección se explica cómo localizar una aplicación XAF ASP.NET Core Blazor. Describe cómo traducir elementos de la interfaz de usuario al alemán y crear una aplicación multilingüe.

> NOTA Para obtener más información sobre la localización, revise los siguientes temas:
> 
> -   [Cómo: Localizar una aplicación XAF .NET 6](https://docs.devexpress.com/eXpressAppFramework/402956/localization/localize-an-xaf-net6-application?v=22.1)
> -   [Conceptos básicos de localización](https://docs.devexpress.com/eXpressAppFramework/112595/localization/localization-basics?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-26)Instrucciones paso a paso

1.  [Agregue](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)  los paquetes  _DevExpress.ExpressApp.de_,  _DevExpress.ExpressApp.Blazor.de_  y  _DevExpress.ExpressApp.Security.de_  al proyecto  **MySolution.Blazor.Server.**
    
    [![image](https://user-images.githubusercontent.com/126447472/254453187-7b47f1a9-6904-4d58-9345-f533d15f3cfc.png)](https://user-images.githubusercontent.com/126447472/254453187-7b47f1a9-6904-4d58-9345-f533d15f3cfc.png)
    
    Los paquetes están disponibles solo para los siguientes idiomas: alemán (de), español (es) y japonés (ja). Para otros idiomas, utilice el  [servicio de localización](https://docs.devexpress.com/LocalizationService/16235/localization-service?v=22.1)  para descargar ensamblados satélite. Consulte el tema  [Localizar módulos XAF estándar y controles DevExpress utilizados en una aplicación](https://docs.devexpress.com/eXpressAppFramework/113301/localization/localize-standard-xaf-modules-and-devexpress-controls-used-in-an-application?v=22.1)  para obtener más información sobre cómo usar este servicio para localizar módulos XAF.
    
2.  En el proyecto  **MySolution.Blazor.Server**, abra el archivo  _appsettings.json._  Agregue el idioma alemán a la sección  _DevExpress:ExpressApp:Languages_  y habilite el  [selector de idioma en tiempo de ejecución](https://docs.devexpress.com/eXpressAppFramework/403027/localization/runtime-language-switcher?v=22.1):
    ```json
    { 
        // ... 
        "DevExpress": { 
            "ExpressApp": { 
                "Languages": "en;de",
                "ShowLanguageSwitcher": true,  
                 // ...
            } 
        } 
    }  
    ```
    Consulte la sección de ayuda Referencia cultural actual en aplicaciones XAF ASP.NET Core Blazor para obtener más información sobre cómo una aplicación  [XAF ASP.NET Core Blazor](https://docs.devexpress.com/eXpressAppFramework/402956/localization/localize-an-xaf-net6-application?v=22.1#current-culture-in-xaf-aspnet-core-blazor-applications)  determina el idioma predeterminado.
    
3.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Enfoque el nodo  _MiSolución_  y haga clic en  **Administrador de idiomas...**  en el cuadro combinado  **Idioma**  de la barra de  [herramientas del Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/113327/ui-construction/application-model-ui-settings-storage/model-editor/menu-toolbars?v=22.1).
    
    [![image](https://user-images.githubusercontent.com/126447472/254453211-99515ef0-43a1-44fa-bb0e-693f7608d660.png)](https://user-images.githubusercontent.com/126447472/254453211-99515ef0-43a1-44fa-bb0e-693f7608d660.png)
    
4.  Agregue el idioma de destino en el cuadro de diálogo invocado y haga clic en  **Aceptar**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453222-d5a7e757-07b5-4986-9a77-3058c555e2a1.png)](https://user-images.githubusercontent.com/126447472/254453222-d5a7e757-07b5-4986-9a77-3058c555e2a1.png)
    
5.  Reinicie Visual Studio para cargar valores localizados de ensamblados satélite.
    
6.  En el Explorador de soluciones, haga clic con el botón secundario en el archivo  _Model.DesignedDiffs.Localization.de.xafml_  y abra la ventana  **Propiedades**. Asegúrese de que el campo  **Acción de compilación**  esté establecido en  **Recurso incrustado**.
    
7.  Seleccione el idioma recién agregado en el cuadro combinado  **Idioma**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453240-065ee6f9-ec7c-4c07-92cb-933f7f289fe7.png)](https://user-images.githubusercontent.com/126447472/254453240-065ee6f9-ec7c-4c07-92cb-933f7f289fe7.png)
    
8.  Los paquetes de localización traducen cadenas/mensajes estándar utilizados en XAF. También debe traducir las cadenas que son exclusivas de la aplicación actual (como los nombres de objetos o propiedades). Para ello, localice las propiedades indicadas por el glifo "globo" en todos los nodos y nodos secundarios y asígneles una traducción al alemán.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453259-208d1481-b28b-4388-9aec-25f5f533a6d8.png)](https://user-images.githubusercontent.com/126447472/254453259-208d1481-b28b-4388-9aec-25f5f533a6d8.png)
    
9.  Ejecute la aplicación. Haga clic en el icono de engranaje para mostrar el menú de configuración y cambiar el idioma a alemán.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453278-f6f5086e-a2b1-436f-926e-5aca09805324.png)](https://user-images.githubusercontent.com/126447472/254453278-f6f5086e-a2b1-436f-926e-5aca09805324.png)
    
10.  Compruebe si ha traducido todos los elementos necesarios. [![image](https://user-images.githubusercontent.com/126447472/254453302-b409406f-2dae-4c7d-8c0c-e8cd1f91fe9b.png)](https://user-images.githubusercontent.com/126447472/254453302-b409406f-2dae-4c7d-8c0c-e8cd1f91fe9b.png)


# Mostrar un editor de propiedades anidadas en una vista detallada

En esta lección se explica cómo hacer que una propiedad (su editor) sea visible en una  [vista de detalles](https://docs.devexpress.com/eXpressAppFramework/112611/ui-construction/views?v=22.1). Las instrucciones siguientes muestran cómo localizar la propiedad anidada  **Department.Office**  y hacerla visible en la Vista de detalles de  **contacto**.

> NOTA Antes de continuar, tómese un momento para repasar la siguiente lección:
> 
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-27)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  Navegar a las  **vistas**  |  **MySolution.Module.BusinessObjects**  |  **Nodo de contacto**. Expanda el nodo secundario  **Contact_DetailView**  y haga clic en el nodo  **Diseño**.
    
3.  El Editor de modelos muestra una superficie de diseño que imita la vista Detalles de  **contacto**. Haga clic con el botón derecho en el espacio vacío de la vista y elija  **Personalizar diseño**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453339-16711afa-641e-4e73-80c4-8477ab7ef308.png)](https://user-images.githubusercontent.com/126447472/254453339-16711afa-641e-4e73-80c4-8477ab7ef308.png)
    
4.  En la ventana  **Personalización**  invocada, haga clic en el botón  **Agregar**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453354-28337034-4130-4129-860b-a517881f4ea6.png)](https://user-images.githubusercontent.com/126447472/254453354-28337034-4130-4129-860b-a517881f4ea6.png)
    
5.  En el cuadro de diálogo  **Modelo de objetos**, expanda el nodo  **Departamento**, active la casilla  **Office**  y haga clic en  **Aceptar**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453372-6f85612d-0aeb-4a5b-80ac-0546415c962e.png)](https://user-images.githubusercontent.com/126447472/254453372-6f85612d-0aeb-4a5b-80ac-0546415c962e.png)
    
6.  El elemento Office: aparece en la pestaña  **Elementos ocultos**  de la ventana  **Personalización:**
    
    [![image](https://user-images.githubusercontent.com/126447472/254453384-564888da-ddf5-49b3-8970-c526cb7680a3.png)](https://user-images.githubusercontent.com/126447472/254453384-564888da-ddf5-49b3-8970-c526cb7680a3.png)
    
7.  Arrastre el elemento  **Office:**  a la posición requerida de la Vista de detalles de  **contacto**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453406-eb746824-137d-4875-b32a-2b2bb810066d.png)](https://user-images.githubusercontent.com/126447472/254453406-eb746824-137d-4875-b32a-2b2bb810066d.png)
    
8.  Ejecute la aplicación, abra la Vista de detalles de  **contacto**  y busque el editor de  **Office**:
    
    [![image](https://user-images.githubusercontent.com/126447472/254453443-adf3430d-4d76-4a0d-bd65-01885d6255d1.png)](https://user-images.githubusercontent.com/126447472/254453443-adf3430d-4d76-4a0d-bd65-01885d6255d1.png)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#change-field-visibility-in-a-list-view)Cambiar la visibilidad de campo en una vista de lista

En esta lección se explica cómo seleccionar las columnas mostradas en una vista de lista. Los pasos siguientes describen cómo personalizar la vista Lista de  **contactos**  en tiempo de diseño.

> NOTA Antes de continuar, tómese un momento para repasar la siguiente lección:
> 
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#step-by-step-instructions-28)Instrucciones paso a paso

1.  Abra el archivo  _Model.DesignedDiffs.xafml_  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1).
    
2.  Haga clic en el  **botón Vistas**  |  **MySolution.Module.BusinessObjects**  |  **Contact_ListView**  |  **Nodo Columnas**  para abrir el  **Diseñador del Editor de listas de cuadrículas**. Haga clic con el botón derecho en el encabezado de la tabla y seleccione  **Selector de columnas**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453422-a3bd36c8-4020-417e-bdc2-18cc539481e9.png)](https://user-images.githubusercontent.com/126447472/254453422-a3bd36c8-4020-417e-bdc2-18cc539481e9.png)
    
3.  Arrastre los elementos hacia y desde la ventana  **Personalización**  para mostrar las siguientes columnas en la vista de lista:  _Nombre completo_,  _Departamento_,  _Puesto_  y  _Correo electrónico_.
    
    También puede cambiar el tamaño y agrupar columnas en el  **Diseñador del editor de listas de cuadrículas**. Consulte la siguiente sección de ayuda para obtener más información:  [Personalización en tiempo de diseño](https://docs.devexpress.com/eXpressAppFramework/113679/ui-construction/views/layout/list-view-columns-customization?v=22.1#1).
    
    Para restablecer la configuración de columna, haga clic con el botón derecho en  **Vistas**  |  **MySolution.Module.BusinessObjects**  |  **Contact_ListView**  |  **Columnas**  y seleccione  **Restablecer diferencias**.
    
4.  Ejecute la aplicación. La vista Lista de  **contactos**  muestra las columnas  _Nombre completo_,  _Departamento_,  _Puesto_  y  _Correo electrónico_.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453457-c04a863a-2fcb-44c8-8756-6347f4e5b0a9.png)](https://user-images.githubusercontent.com/126447472/254453457-c04a863a-2fcb-44c8-8756-6347f4e5b0a9.png)
    

# [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#change-list-view-filters)Cambiar filtros de vista de lista

En esta lección se describen tres técnicas utilizadas para filtrar una vista de lista. Los filtros se aplicarán a la vista Lista de  **contactos**.

> NOTA Antes de continuar, tómese un momento para repasar las siguientes lecciones:
> 
> -   Heredar de la clase de biblioteca de clase empresarial (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402166/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/inherit-from-the-business-class-library-class-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402981/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/inherit-from-the-business-class-library-class-ef-core?v=22.1)))
> -   Implementar clases empresariales personalizadas y propiedades de referencia (núcleo  [XPO/](https://docs.devexpress.com/eXpressAppFramework/402163/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/implement-custom-business-classes-and-reference-properties-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402978/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/implement-custom-business-classes-and-reference-properties-ef-core?v=22.1)))
> -   Establecer una relación de uno a varios ([XPO/](https://docs.devexpress.com/eXpressAppFramework/402169/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/set-a-one-to-many-relationship-xpo?v=22.1)[EF](https://docs.devexpress.com/eXpressAppFramework/402984/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/set-a-one-to-many-relationship-ef-core?v=22.1))
> -   Filtrar origen de datos para un editor de búsquedas ([XPO](https://docs.devexpress.com/eXpressAppFramework/404170/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-xpo/filter-data-source-for-lookup-editor-xpo?v=22.1)[EF Core](https://docs.devexpress.com/eXpressAppFramework/402139/getting-started/in-depth-tutorial-blazor/business-model-design/business-model-design-with-ef-core/filter-lookup-editor-data-source-ef-core?v=22.1)
> -   [Colocar una acción en una ubicación diferente](https://docs.devexpress.com/eXpressAppFramework/402145/getting-started/in-depth-tutorial-blazor/ui-customization/place-an-action-in-a-different-location?v=22.1)

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#show-a-filter-action)Mostrar una acción de filtro

Esta técnica permite a los usuarios finales aplicar filtros predefinidos a una vista de lista.

1.  Abra el archivo  **Model.DesignedDiffs.xafml**  en el Editor de  [modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Navegar a las  **vistas**  |  **MySolution.Module.BusinessObjects**  |  **Contact_ListView**  nodo. Haga clic con el botón derecho en el nodo secundario  **Filtros**  y seleccione  **Agregar**  |  **ListViewFilterItem**. Para el nuevo nodo, establezca la propiedad  **Id**  en  _Contactos del departamento de desarrollo_. Establezca la propiedad  **Criteria**  en .`[Department.Title] = 'Development Department'`
    
    [![image](https://user-images.githubusercontent.com/126447472/254453478-3b8c2b40-abdd-4a48-b92e-cdafe66d7de1.png)](https://user-images.githubusercontent.com/126447472/254453478-3b8c2b40-abdd-4a48-b92e-cdafe66d7de1.png)
    
    **Las propiedades Criteria**  utilizan  [la sintaxis del lenguaje de criterios](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax?v=22.1).
    
    También puede crear un criterio de filtro en el cuadro de diálogo  **Generador de filtros**. Para abrir este cuadro de diálogo, haga clic en el botón de puntos suspensivos ([![EllipsisButton](https://camo.githubusercontent.com/2ba2ee67a57b7dcbfd265715bf94f4bda1e01aa2f93fefc791fba5c403cd0bc0/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f656c6c6970736973627574746f6e3131363138322e706e673f763d32322e31)](https://camo.githubusercontent.com/2ba2ee67a57b7dcbfd265715bf94f4bda1e01aa2f93fefc791fba5c403cd0bc0/68747470733a2f2f646f63732e646576657870726573732e636f6d2f655870726573734170704672616d65776f726b2f696d616765732f656c6c6970736973627574746f6e3131363138322e706e673f763d32322e31)) situado a la derecha del valor  **Criterios**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453530-d104aeaf-7ecd-451f-9230-f9c011a560bc.png)](https://user-images.githubusercontent.com/126447472/254453530-d104aeaf-7ecd-451f-9230-f9c011a560bc.png)
    
2.  Agregue otro nodo secundario al nodo  **Filtros**. Establezca la propiedad  **Id**  en  _Developers_  y la propiedad  **Criteria**  en .`[Position.Title] = 'Developer'`
    
    [![image](https://user-images.githubusercontent.com/126447472/254453553-45a51e96-fb2b-4889-924d-491140833f31.png)](https://user-images.githubusercontent.com/126447472/254453553-45a51e96-fb2b-4889-924d-491140833f31.png)
    
3.  Agregue un nodo secundario más al nodo  **Filtros**. Establezca la propiedad  **Id**  en  _Todos los contactos_  y deje vacía la propiedad  **Criterios**. Este elemento mostrará todos los objetos  **Contact**  en la vista de lista.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453573-a298bcf3-bab2-4341-95f5-db631c0832ff.png)](https://user-images.githubusercontent.com/126447472/254453573-a298bcf3-bab2-4341-95f5-db631c0832ff.png)
    
4.  Para el nodo  **Filters**, establezca la propiedad  **CurrentFilter**  en  _Developers_. El filtro Desarrolladores se aplicará inicialmente a la vista Lista de  **contactos**.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453588-7a092d3b-f190-4618-b262-73541687fe0d.png)](https://user-images.githubusercontent.com/126447472/254453588-7a092d3b-f190-4618-b262-73541687fe0d.png)
    
5.  Ejecute la aplicación y compruebe que la acción  **SetFilter**  está disponible.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453608-aa8215f7-2dd6-469f-8965-618679afef6c.png)](https://user-images.githubusercontent.com/126447472/254453608-aa8215f7-2dd6-469f-8965-618679afef6c.png)
    

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#set-a-static-filter-in-the-model-editor)Establecer un filtro estático en el editor de modelos

El  **Editor de modelos**  también permite filtrar los registros de la vista de lista sin ninguna indicación en la interfaz de usuario.

1.  En el proyecto  _MySolution.Module_, abra el archivo  **Model.DesignedDiffs.xafml**  en el  [Editor de modelos](https://docs.devexpress.com/eXpressAppFramework/112582/ui-construction/application-model-ui-settings-storage/model-editor?v=22.1). Navegar a las  **vistas**  |  **MySolution.Module.BusinessObjects**  |  **Contacto**  |  **Contact_ListView**  nodo. Establezca su propiedad  **Criteria**  en .`Position.Title = 'Developer'`
    
    [![image](https://user-images.githubusercontent.com/126447472/254453629-adbe2c44-1f0f-4112-a3e5-6a73c7051e05.png)](https://user-images.githubusercontent.com/126447472/254453629-adbe2c44-1f0f-4112-a3e5-6a73c7051e05.png)
    
2.  Ejecute la aplicación y compruebe que la vista Lista de  **contactos**  muestra solo desarrolladores.
    
    [![image](https://user-images.githubusercontent.com/126447472/254453636-3a7f9da1-0c19-4125-ab94-c0dff071f9d0.png)](https://user-images.githubusercontent.com/126447472/254453636-3a7f9da1-0c19-4125-ab94-c0dff071f9d0.png)
    

## [](https://github.com/jjcolumb/In-Depth-XAF-ASP.NET-Core-Blazor-UI-Tutorial#set-a-filter-in-code)Establecer un filtro en el código

Puede crear filtros que no se pueden deshabilitar en la interfaz de usuario de la aplicación ni en el Editor de modelos.

1.  En el  **Explorador de soluciones**, haga clic con el botón secundario en la carpeta  _Controllers_  del proyecto  _MySolution.Module_  y elija  **Agregar elemento DevExpress**  |  **Nuevo artículo...**  para invocar la  [Galería de plantillas](https://docs.devexpress.com/eXpressAppFramework/113455/installation-upgrade-version-history/visual-studio-integration/template-gallery?v=22.1).
    
2.  Seleccione los  **controladores XAF**  |  **Controlador de vista**  Plantilla de Visual Studio. Especifique  _FilterListViewController_  como nombre del nuevo elemento y haga clic en  **Agregar elemento**.
    
3.  En el archivo  _FilterListViewController.cs_  generado automáticamente, herede el controlador de  [ObjectViewController<ViewType, ObjectType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ObjectViewController-2?v=22.1):
    ```csharp
    using DevExpress.Data.Filtering;
    using DevExpress.ExpressApp;
    using MySolution.Module.BusinessObjects;
    // ...
    
    public partial class FilterListViewController : ObjectViewController<DetailView, Contact> {
        public FilterListViewController() {
            InitializeComponent();
        }
        // ...
    }
    ```
4.  Anule el método:`OnActivated`
    ```csharp
    public partial class FilterListViewController : ObjectViewController<DetailView, Contact> {
        // ... 
        protected override void OnActivated() {
            base.OnActivated();
            //Specify a filter criteria.
            View.CollectionSource.Criteria["Developers"] = CriteriaOperator.FromLambda<Contact>(c => c.Position.Title == "Developer");
        }
        // ...
    }
    ```
5.  Ejecute la aplicación y compruebe el filtro en la vista Lista de  **contactos**.
