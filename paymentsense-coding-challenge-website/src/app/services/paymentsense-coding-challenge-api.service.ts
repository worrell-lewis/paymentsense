import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CountryData } from '../models/country-data.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentsenseCodingChallengeApiService {
  allCountryData :CountryData[];

  constructor(private httpClient: HttpClient) {}

  public getHealth(): Observable<string> {
    return this.httpClient.get('https://localhost:44341/health', { responseType: 'text' });
  }

  public getCountryData() : Observable<CountryData[]> {
     
    return this.httpClient.get<CountryData[]>('https://localhost:44341/PaymentsenseCodingChallenge/AllCountryData');    
  }
}
