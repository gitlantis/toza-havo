import { Component, EventEmitter, Input, Output } from '@angular/core';
import { StationLocation } from 'src/helpers/instant-data.model';

@Component({
  selector: 'app-banner-card',
  templateUrl: './banner-card.component.html',
  styleUrls: ['./banner-card.component.css']
})
export class BannerCardComponent {

  @Input() aqi?: number;
  @Input() pm2_5?: number;
  @Input() stations?: StationLocation[];

  constructor() { }

  ngOnInit() {
  }

}
