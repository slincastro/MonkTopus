# Herramienta `payphone`
La herramienta `payphone` te ayuda a generar a un scaffolding de un proyecto considerando principios de arquitectura limpia y algunas buenas prácticas de desarrollo, como lo es desarrollo basado en pruebas (TDD), pruebas de aceptación (BDD)  pruebas de arquitectura usando ArcUnitNet, monitoreo con App Insight.

La arquitectura de la solución que es generada se compone de 4 capas.

* Domain
* Application
* Infrastructure
* Presentation

Respecto a los proyectos de pruebas encontrarás los siguientes:

* Proyecto para pruebas unitarias (TDD)
* Proyecto para pruebas de aceptación (BDD)
* Proyecto para pruebas de arquiectura
* Proyecto para pruebas de performance

## ¿Cómo generar un proyecto usando la herramienta `payphone`?

1. Crea un directorio o crea un repositorio vacío y clónalo en tu computador.
2. Abre una terminal en el path de ese directorio.
3. Ejecuta el comando: `payphone ica --projectName [nombre de tu proyecto]`

## ¿Cómo añado una clase en alguna de las capas?

* Para añadir una clase en la capa Domain puedes ejectuar el comando: `payphone nd --className [nombre de tu clase]`
* Para añadir una clase en la capa Application puedes ejectuar el comando: `payphone na --className [nombre de tu clase]`
* Para añadir una clase en la capa Infrastructure puedes ejectuar el comando: `payphone ni --className [nombre de tu clase]`
* Para añadir una clase en la capa Presentation puedes ejectuar el comando: `payphone np --className [nombre de tu clase]`

Nota: Cada uno de los 4 comandos creará tanta la clase como su clase para pruebas unitarias.

## ¿Cómo genero el reporte de cobertura de pruebas?

Para ello ejecuta el comando  `payphone rut`
El repositorio se generará en en la ruta [nombre de tu clase]Test/UnitTests/TestResults/coveragereport

Nota: todos los comandos deben ejecutarse desde el directorio raíz del proyecto
