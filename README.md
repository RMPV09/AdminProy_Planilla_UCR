# Planilla_UCR
El objetivo de este proyecto es poder proporcionar una aplicaciòn que permita realizar el pago de planillas de forma fàcil, eficiente y segura.


# Integrantes

● Leonel Campos Murillo. B91545.  
● Nayeri Azofeifa Porras. B90841.  
● Wendy Ortiz Alfaro. B75584.  
● Ronald Mauricio Palma Villegas. B95811.  
● Jeremy Vargas Artavia. B98157.  

# Crear base de datos de autenticación

## instalar desde powershell:
dotnet tool install --version 5.0.11 --global dotnet-ef

## Con el servidor web como proyecto por defecto. y la capa de infraestructura seleccionada.
## Desde el Package manager console ejecutar:
Update-Database -Context AccountsDbContext
