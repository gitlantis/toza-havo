import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
// import { param } from 'jquery';
import { ArchiveData } from 'src/helpers/archive-data.model';
import { DataService } from 'src/services/data.service';

@Component({
  selector: 'app-modal-archive',
  templateUrl: './modal-archive.component.html',
  styleUrls: ['./modal-archive.component.css']
})

export class ModalArchiveComponent implements OnInit {
  @Input() public guid: any;
  @Input() public stationName: any;

  public archive = new Array<ArchiveData>();
  public params = new ArchiveData();

  constructor(private modalService: NgbModal, private dataService: DataService) { }

  ngOnInit(): void {
    this.params.dataCount = 0;
    this.params.pageNum = 1;
    this.params.itemCount = 2;
    this.getArchive(this.params.pageNum, +this.params.itemCount);
  }

  closeModal() {
    const modalRef = this.modalService.dismissAll(ModalArchiveComponent);
  }

  counter(i: number) {
    return new Array(i);
  }

  getArchive(pageNum?: number, itemCount?: number) {

    this.params.stationGuid = this.guid;

    if (itemCount != null)
      this.params.itemCount = +itemCount;
    if (pageNum != null)
      this.params.pageNum = pageNum;

    this.dataService.getArchive(this.params)
      .subscribe(
        res => {
          this.archive = res;
          this.params.pageCount = this.archive[0].pageCount * 10;
        },
        err => {
          console.log(err)
        })


  }

}
