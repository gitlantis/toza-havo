import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from 'src/constants';
import { Observable } from 'rxjs';
import { DynamicData } from 'src/helpers/dynamic-data.model';
import { DeviceConfig } from 'src/helpers/device-config.model';
import { DeviceConfigItems } from 'src/helpers/device-config-items';
import { BaseService } from './base.service';
import { UserService } from './user.service';
import { ToastrService } from 'ngx-toastr';
import { ArchiveData } from 'src/helpers/archive-data.model';
@Injectable({
  providedIn: 'root'
})
export class DataService extends BaseService {

  resp: null;

  constructor(httpClient: HttpClient, router: Router, constants: Constants, userService: UserService, private toastr: ToastrService) {
    super(httpClient, router, constants)
  }

  getDevices(): Observable<DynamicData[]> {
    return this.httpClient.post<DynamicData[]>(this.constants.baseUrl + '/DeviceData/GetDynamicData', "") as Observable<DynamicData[]>
  }

  getConfig(guid): Observable<Array<DeviceConfigItems>> {
    return this.httpClient.post<Array<DeviceConfigItems>>(this.constants.baseUrl + '/Device/GetConfigItems', JSON.stringify(guid))
  }

  postConfig(formData) {
    return this.httpClient.post(this.constants.baseUrl + '/Device/UpdateConfigValues', formData).subscribe(
      res => {
        this.toastr.success('Configuration saved!', 'Configuration!');
      },
      err => {
        this.toastr.error('Check configuration ranges!', 'Data error!');
      });
  }

  getArchive(data): Observable<Array<ArchiveData>> {
    return this.httpClient.post<Array<ArchiveData>>(this.constants.baseUrl + '/DeviceData/GetArchive', JSON.stringify(data))
  }

  toRawArchValue<T extends ArchiveData>(requestData: ArchiveData): ArchiveData {
    return {
      deviceGuid: requestData.deviceGuid,
      name: requestData.name,
      dataCount: requestData.dataCount,
      itemCount: requestData.itemCount,
      pageNum: requestData.pageNum,
      rowCount: requestData.rowCount,
      createdDate: requestData.createdDate,
      ai: requestData.ai,
      ao: requestData.ao,
      di: requestData.di,
      do: requestData.do,
      metadata: requestData.metadata,
      pageCount: requestData.pageCount
    }
  }

}



