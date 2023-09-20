import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { DataService } from 'src/services/data.service';
import { ToastrService } from 'ngx-toastr';
import { StationConfigItems } from 'src/helpers/station-config-items';

@Component({
  selector: 'app-modal-content',
  templateUrl: './modal-content.component.html',
  styleUrls: ['./modal-content.component.css']
})
export class ModalContentComponent implements OnInit {
  @Input() public guid: any;
  @Input() public stationName: any;
  myModel: any
  stationConfig: Array<StationConfigItems> = [];
  colNames?: string[];
  pageSize?: number;
  bDate?: string;
  eDate?: string;

  constructor(private modalService: NgbModal, private dataService: DataService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getConfig(this.guid)
  }

  getConfig(guid: string) {
    this.dataService.getConfig(guid)
      .subscribe(
        res => {
          this.stationConfig = res as StationConfigItems[];
          console.log(this.stationConfig)
        },
        err => {
          this.toastr.error(err.message, 'Config read error!');
        })
  }

  closeModal() {
    this.modalService.dismissAll(ModalContentComponent);
  }

  onSubmit(form: any) {
    for (let key in form) {
      (this.stationConfig as any).find((c: { confGuid: string; }) => c.confGuid == key).value = String(form[key]);
    }

    this.dataService.postConfig(this.stationConfig)
  }

}
