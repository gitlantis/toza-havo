import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InstantData } from 'src/helpers/instant-data.model';
import { RequestWithId } from 'src/helpers/request-with-id.model';
import { StationData } from 'src/helpers/station-data.model';
import { DataService } from 'src/services/data.service';

@Component({
  selector: 'app-home-screen',
  templateUrl: './home-screen.component.html',
  styleUrls: ['./home-screen.component.css']
})
export class HomeScreenComponent {
  device = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
  instantData?: InstantData;
  requestId: RequestWithId = { id: this.device }

  constructor(private modalService: NgbModal, private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getInstantData(this.requestId).subscribe(res => {
      this.instantData = res as InstantData;
    })
  }

  public open(modal: any): void {
    this.modalService.open(modal);
  }
}
