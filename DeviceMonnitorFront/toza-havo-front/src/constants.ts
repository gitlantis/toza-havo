import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Constants {
  readonly baseUrl = 'http://95.130.227.149:8080/api'
  // readonly baseUrl = 'http://localhost:5000/api'
}