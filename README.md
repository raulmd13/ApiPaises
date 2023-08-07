# 🥷 Codechallenge [![dotnet](https://img.shields.io/badge/dotnet-7.0-purple)](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Realizar un microservicio en `.net 7` usando el lenguaje de programación `C#` con las siguientes indicaciones:

## 🗺️ **(2 puntos)**  Generar un un controlador que permita realizar un `CRUD` sobre la entidad `Country`, tendrá los siguientes campos:

- name
- alpha2Code
- alpha3Code
- capital
- region
- nativeName

## 🚩 **(2 puntos)** Generar un controlador que consuma el api pública: https://restcountries.com y contenga

_(En caso de que la url del api esté en mantenimiento o no responda, puedes realizar los apartados que la requieran usando otro api publica pero intentado cumplir los mismos objetivos de la pregunta en otro controlador)_

- _(0.5)_  GET que permita consultar todos los países.
- _(0.5)_ GET que permita consultar un país por nombre.
- _(1)_ GET que permita recuperar una cadena de texto base64 de la bandera (flag) svg de un país concreto.

## 🌍 **(2 puntos)** Agregar un POST al controlador del apartado anterior que permita transferir la información de un país (Country) del api al modelo del microservicio para almacenarlo.

## ✨ **(4 puntos)** Se valorará
- _(1)_ 💾 Sistema de persistencia de datos.
- _(1)_ 📖 La documentación del microservicio (swagger/openapi).
-  _(1)_ 👁️ Un sistema de log y test que permite ver el flujo del microservicio y testearlo.
- _(1)_ 📚  Cualquier dependencia o concepto que ayude a la solución del ejercicio, limpieza del código, patrones, estilo de desarrollo y buenas prácticas.







