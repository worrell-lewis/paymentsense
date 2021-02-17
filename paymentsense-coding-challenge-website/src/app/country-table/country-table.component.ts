import { Component, OnInit } from '@angular/core';
import { CountryData } from '../models/country-data.model';
import { PaymentsenseCodingChallengeApiService } from '../services';

@Component({
  selector: 'app-country-table',
  templateUrl: './country-table.component.html'
})
export class CountryTableComponent implements OnInit {
  allCountryData: CountryData[];

  constructor(private readonly countryApiService :PaymentsenseCodingChallengeApiService) { 
    this.getData();

  }

  ngOnInit() {
  }

  getData(){
     this.countryApiService.getCountryData().subscribe(result => this.allCountryData = result);
  }

}
