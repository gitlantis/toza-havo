import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Constants {
  // readonly baseUrl = 'http://api.webscada.uz/api'  
  readonly baseUrl = 'http://localhost:5000/api'  
}