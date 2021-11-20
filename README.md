Clone the repo to your local machine.
Build the Project then run it, Swagger UI will appear
Open SQL Server and connect to the local server: (LocalDB)\MSSQLLocalDB
Open this script in SQL Sever: ScripToInsertRates.sql (BackendDB is the database name)
Run the script first everytime you run the solution, then in swagger go to the endpoint "ConvertUnit"
Provide the required data (amount is the measurement you want to convert, unit is the conversion you want to perfom as shown below)
        Conversion to perform - values
        CelsiusToFahrenheit - 0
        FahrenheitToCelsius - 1
        SecondsToMinutes - 2
        MinutesToSeconds - 3
        MetricToImperial - 4
        ImperialToMetric - 5
