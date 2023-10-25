# CallCenter-.Net-Equipo-15

Propuesta Call Center

Se requiere una aplicación web para ingresar los reclamos de clientes que se toman
dentro de un call center. Para poder ingresar el reclamo, el cliente debe estar dado de alta, con lo
cual se debe contar con administración de clientes.
Para dar de alta un incidente se debe seleccionar el cliente, el tipo de incidencia (administrable), la prioridad (administrable) y agregar la problemática. El sistema deberá manejar seguridad y distintos perfiles: Administrador, Telefonista y Supervisor. Cada vez que se ingrese una incidencia, ésta quedará asignada a su usuario creador, pero el Supervisor podrá cambiar la asignación en cualquier momento. Además para los incidentes se debe manejar un modelo de estados (Abierto, En Análisis, Cerrado, Reabierto, Asignado, Resuelto), que será administrado automáticamente a medida que se gestione el reclamo. Un incidente nace en estado “Abierto”, pasa a "Asignado" cuando se reasigna; a “En Análisis” cuando se lo modifica por algún motivo. Una vez que se dio una respuesta satisfactoria se pasa a "Resuelto" con un botón "Resolver" que pedirá algún dato adicional final; y por último, el incidente puede ser cerrado desde un botón “Cerrar Incidencia”. Cuando se cierra, sí o sí debe pedir un comentario final de cierre. Un incidente puede ser cerrado por distintos motivos distintos a no haber llegado a una solución, por eso es distinto de "Resuelto".
El estado no puede ser cambiado manualmente por los usuarios.
Un incidente no debería ser eliminado nunca.
Con respecto a la visibilidad, los telefonistas podrán ver y administrar clientes e incidencias, pero
sólo ver las incidencias asignadas a ellos. El administrador podrá ver y manipular todo, inclusive usuarios y accesos y el Supervisor es quien puede ver todo y reasignar incidencias.
Cuando se da de alta una incidencia, la misma debe ser enviada por mail al cliente en cuestión con
el detalle del alta y el número de reclamo para su posterior seguimiento, lo mismo cuando fue
cerrada o resuelta.

Integrantes: Ignacio Ezequiel Bee Bianco / Dante Beltran Nanziot / Manuel Ignacio Usoz Neri
