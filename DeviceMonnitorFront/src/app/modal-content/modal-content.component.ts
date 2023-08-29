import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from 'src/services/data.service';
import { ToastrService } from 'ngx-toastr';
import { DeviceConfigItems } from 'src/helpers/device-config-items';

@Component({
  selector: 'app-modal-content',
  templateUrl: './modal-content.component.html',
  styleUrls: ['./modal-content.component.css']
})
export class ModalContentComponent implements OnInit {
  @Input() public guid;
  @Input() public deviceName;
  myModel: any
  deviceConfig: Array<DeviceConfigItems>;
  colNames: string[];
  pageSize: number;
  bDate: string;
  eDate: string;

  constructor(private modalService: NgbModal, private dataService: DataService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getConfig(this.guid)
  }

  getConfig(guid) {
    this.dataService.getConfig(guid)
      .subscribe(
        res => {
          this.deviceConfig = res;          
        },
        err => {
          this.toastr.error(err.message, 'Config read error!');
        })
  }

  closeModal() {
    this.modalService.dismissAll(ModalContentComponent);
  }

  onSubmit(form) {

    for (let key in form) {
      this.deviceConfig.find(c => c.confGuid == key).value = form[key];
    }

    this.dataService.postConfig(this.deviceConfig)
  }

}
