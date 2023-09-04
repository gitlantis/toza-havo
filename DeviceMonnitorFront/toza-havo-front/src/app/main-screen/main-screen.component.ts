import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/services/auth.service';
import { DataService } from 'src/services/data.service';
import { ModalContentComponent } from '../modal-content/modal-content.component';
import { interval, Observable } from 'rxjs';
import { UserService } from 'src/services/user.service';
import { HttpClient } from '@microsoft/signalr';
import { DynamicData } from 'src/helpers/dynamic-data.model';
import { Constants } from 'src/constants';
import { HttpHeaders } from '@angular/common/http';
import { ModalArchiveComponent } from '../modal-archive/modal-archive.component';
import { PanelData } from 'src/helpers/panel-data.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent implements OnInit {
  userName?: string;
  closeModal?: string;
  panels = new Map<string | undefined, Array<PanelData>>()
  oldPanels = new Map<string | undefined, Array<PanelData>>()
  constants = new Constants()
  timeZoneOffset = new Date().getTimezoneOffset();
  utcDate = new Date('08/08/2019 13:07:48 PM UTC');
  // |  date:'yyyy-MM-dd HH:mm:ss':timeZoneOffset.toString()
  public header = new HttpHeaders({ 'Content-Type': 'application/JSON', 'Authorization': 'Bearer ' + UserService.getToken() });

  constructor(private authService: AuthService, private dataService: DataService, private modalService: NgbModal,
    private userService: UserService, private router: Router) { }

  devices: DynamicData[] | undefined;
  datacount = 0;
  ngOnInit(): void {
    this.oldPanels
    this.panels = new Map<string, Array<PanelData>>()

    this.userName = (UserService.getUsername() as string);
    this.getDevices();

    // interval(3000).subscribe(a => {
    //   this.getDevices();
    // });
  }

  logOut() {
    this.authService.logout();
  }

  getDevices() {

    this.oldPanels = this.panels
    var tmpPanels = new Map<string, Array<PanelData>>()

    this.dataService.getDevices().subscribe(res => {
      this.devices = res as DynamicData[];
      this.devices.forEach(element => {

        var arr = new Array<PanelData>();
        var deviceGuid = element.deviceGuid as string;

        var tmp = new PanelData;
        tmp.deviceGuid = deviceGuid
        if (this.oldPanels.size > 0)
          tmp.active = this.oldPanels.get(deviceGuid)![0].active
        tmp.id = 0;
        tmp.name = "Data";
        tmp.values = element.ai;
        arr.push(tmp)

        tmpPanels.set(element.deviceGuid as string, arr);
      });

      this.panels = tmpPanels;
    },
      err => {
        console.log(err);
      });
  }

  getConfig(guid?: string, deviceName?: string) {
    const modalRef = this.modalService.open(ModalContentComponent, { size: 'lg' });
    modalRef.componentInstance.guid = guid;
    modalRef.componentInstance.deviceName = deviceName;
  }

  getArchive(guid?: string, deviceName?: string) {
    const modalRef = this.modalService.open(ModalArchiveComponent, { size: 'lg' });
    modalRef.componentInstance.guid = guid;
    modalRef.componentInstance.deviceName = deviceName;
  }

  counter(i: number) {
    return new Array(i);
  }

  collapser(deviceGuid: string = "", panelId: number = 0) {
    this.panels.get(deviceGuid)!.forEach(element => {
      if (element.deviceGuid === deviceGuid && element.id == panelId) {
        this.panels.get(deviceGuid)![panelId].active = !this.panels.get(deviceGuid)![panelId].active
      }
    });
  }

  compareDates(date: any) {

    let validDate = '1900-01-01T00:00:00'

    if (date > validDate)
      return true;
    return false
  }
}
