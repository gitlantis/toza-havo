export class InstantData {
    stationLocations?: StationLocation[]
    aqi?: number
    pm1_0?: number
    pm2_5?: number
    pm10?: number
    co2?: number
    temperature?: InstantValue
    humadity?: InstantValue
    pressure?: InstantValue
    windSpeed?: InstantValue
    solarRadiation?: InstantValue
}

export class StationLocation {
    id?: string
    locationName?: string
    latitude?: number
    langitude?: number
    altitude?: number
}

export class InstantValue {
    currentValue?: number
    subCurrentValue?: number
    min?: number
    avg?: number
    max?: number
}