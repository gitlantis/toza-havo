import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Constants {
  // readonly baseUrl = 'http://api.webscada.uz/api'  
  readonly baseUrl = 'https://localhost:5001/api'  
}