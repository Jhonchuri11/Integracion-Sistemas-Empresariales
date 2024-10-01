Compresión de aplicación de capas de negocio para la implementación de diversas  funciones y sirve como intermediario para métodos base como puente de conexión. Caso contrario con capa datos que almacena todo completo el conocido CRUD, create, read, update and delete.

# Aplicación de Capas de Negocio y Capa de Datos

Este documento describe la **compresión** y **aplicación** de capas en una arquitectura de software, enfocada en la implementación de funciones de negocio y su relación con la capa de datos.

## Capa de Negocio

La capa de negocio actúa como intermediario entre la capa de presentación (la interfaz de usuario) y la capa de datos. Se encarga de implementar diversas funciones y lógicas que son esenciales para el funcionamiento del sistema.

## Capa de Presentación

En esta capa se colocan los formularios o ventanas en el caso de uso WPF

### Funciones de la Capa de Negocio:
- **Intermediario**: Sirve como puente entre los métodos base y la capa de datos.
- **Implementación de Lógicas**: Procesa las reglas de negocio antes de interactuar con la base de datos.
  
Por ejemplo, se utiliza como intermediario para la ejecución de acciones como la validación de datos, el cálculo de impuestos, y la aplicación de descuentos.

## Capa de Datos

La capa de datos es responsable del **almacenamiento** y la **gestión** de la información en el sistema. Realiza operaciones conocidas como **CRUD** (Create, Read, Update, Delete), permitiendo la interacción directa con la base de datos.

### Funciones del CRUD:
1. **Create**: Inserta nuevos registros en la base de datos.
2. **Read**: Lee y recupera datos desde la base de datos.
3. **Update**: Actualiza los registros existentes.
4. **Delete**: Elimina registros que ya no son necesarios.