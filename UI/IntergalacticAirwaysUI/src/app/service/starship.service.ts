import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Starship } from '../model/starship';
@Injectable({
  providedIn: 'root'
})
export class StarshipService {

  constructor(private httpClient: HttpClient) { }

  search(passengerCount: number){
    return this.httpClient.get<Starship[]>(environment.apiUrl + `/api/Starship/${passengerCount}`)
  }
}
