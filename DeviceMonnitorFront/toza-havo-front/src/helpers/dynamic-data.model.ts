import { DataParts } from "./child-data.model"

export class DynamicData {
    deviceGuid?: string
    name?: string
    lastDataTime?: Date
    isWorking?: boolean
    isActive?: boolean
    rowCount?: number
    ai?: Array<DataParts>
    di?: Array<DataParts>
    metadata?: Array<DataParts>
}