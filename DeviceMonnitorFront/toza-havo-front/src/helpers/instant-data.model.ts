export class InstantData {
    stationLocations?: StationLocation[]
    aqi?: number
    pm1_0?: number
    pm2_5?: number
    pm10?: number
    co2?: number
    instantValues?: InstantValue[]
}

export class StationLocation {
    id?: string
    locationName?: string
    latitude?: number
    langitude?: number
    altitude?: number
}

export class InstantValue {
    section?: string
    currentValue?: number
    subCurrentValue?: number
    average?: number
    min?: number
    avg?: number
    max?: number
}