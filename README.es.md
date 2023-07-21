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
