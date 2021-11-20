use backenddb
go

insert into ConversionRate
select 'CelsiusToFahrenheit','Converts celsius to fahrenheit',1.8,32,'°F'
union all
select 'FahrenheitToCelsius','Converts fahrenheit to celsius',0.5555555555555556,32,'°C'
union all
select 'SecondsToMinutes','Converts seconds to minutes',0.0166666666666667,0,'min'
union all
select 'MinutesToSeconds','Converts minutes to seconds',60,0,'sec'
union all
select 'MetricToImperial','Converts metric to imperial',0.03937,0,'in'
union all
select 'ImperialToMetric','Converts imperial to metric',25.400050,0,'mm'
