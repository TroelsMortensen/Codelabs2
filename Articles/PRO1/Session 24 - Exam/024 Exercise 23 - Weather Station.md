# Exercise 23 - Weather Station System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class WeatherStation {
        - stationId : String
        - location : String
        - elevation : double
        - installationDate : LocalDate
        + WeatherStation(stationId : String, location : String, elevation : double, installationDate : LocalDate)
        + getStationId() String
        + recordReading(reading : WeatherReading) void
        + getReadings() ArrayList~WeatherReading~
        + getAverageTemperature(startDate : LocalDate, endDate : LocalDate) double
        + getRainfall(startDate : LocalDate, endDate : LocalDate) double
    }
    
    class WeatherReading {
        - readingId : int
        - timestamp : LocalDateTime
        - temperature : double
        - humidity : int
        - pressure : double
        - windSpeed : double
        - windDirection : String
        + WeatherReading(readingId : int, timestamp : LocalDateTime, temperature : double, humidity : int, pressure : double)
        + getTimestamp() LocalDateTime
        + getTemperature() double
        + getHumidity() int
        + getCondition() String
        + isSevere() boolean
    }
    
    class Alert {
        - alertId : int
        - alertType : String
        - severity : String
        - message : String
        - issueTime : LocalDateTime
        - expiryTime : LocalDateTime
        + Alert(alertId : int, alertType : String, severity : String, message : String, issueTime : LocalDateTime, expiryTime : LocalDateTime)
        + getAlertType() String
        + isActive() boolean
        + getSeverity() String
    }
    
    class Forecast {
        - forecastId : int
        - forecastDate : LocalDate
        - minTemp : double
        - maxTemp : double
        - precipitationChance : int
        - condition : String
        + Forecast(forecastId : int, forecastDate : LocalDate, minTemp : double, maxTemp : double, precipitationChance : int, condition : String)
        + getForecastDate() LocalDate
        + getMinTemp() double
        + getMaxTemp() double
        + getCondition() String
    }
    
    class HourlyForecast {
        - hour : int
        - temperature : double
        - precipitation : double
        + getTemperature() double
    }
    
    class DailyForecast {
        - sunrise : String
        - sunset : String
        - uvIndex : int
        + getSunrise() String
    }
    
    class WeeklyForecast {
        - weekStartDate : LocalDate
        - averageTemp : double
        + getAverageTemp() double
    }
    
    WeatherStation --> "*" WeatherReading : readings
    WeatherStation --> "*" Alert : alerts
    WeatherStation --> "*" Forecast : forecasts
    HourlyForecast --|> Forecast
    DailyForecast --|> Forecast
    WeeklyForecast --|> Forecast
```

## Notes:
- Severe conditions: temperature > 35°C or < -20°C, wind speed > 100 km/h, pressure < 980 hPa
- Alert severity levels: "Low", "Moderate", "High", "Extreme"
- Alert types: "Storm", "Heat", "Cold", "Flood", "Wind"
- Conditions: "Sunny", "Cloudy", "Rainy", "Snowy", "Stormy", "Foggy"
- Temperature in Celsius, pressure in hPa (hectopascals), wind speed in km/h
- Use `java.time.LocalDate` and `java.time.LocalDateTime` for time handling

