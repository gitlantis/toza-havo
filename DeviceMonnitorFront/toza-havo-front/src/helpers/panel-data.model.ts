export class PanelData {
    stationGuid?: string
    id?: number
    active?: boolean
    name?: string
    disabled?: boolean = false
    paramSubDomain?: Array<string>
    paramName?: Array<string>
    paramDesc?: Array<string>
    values?: Array<any>
}