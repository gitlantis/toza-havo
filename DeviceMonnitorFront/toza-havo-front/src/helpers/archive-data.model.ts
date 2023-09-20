import { DataParts } from "./child-data.model"

export class ArchiveData {
    stationGuid?: string
    name?: string
    dataCount?: number
    itemCount?: number
    pageNum?: number
    rowCount?: number
    createdDate?: Date
    pageCount: number = 0
    ai?: Array<DataParts>
    ao?: Array<DataParts>
    di?: Array<DataParts>
    do?: Array<DataParts>
    metadata?: Array<DataParts>
}