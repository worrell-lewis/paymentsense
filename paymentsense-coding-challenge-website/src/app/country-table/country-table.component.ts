import { Component, OnInit } from '@angular/core';
import { CountryData } from '../models/country-data.model';
import { PaymentsenseCodingChallengeApiService } from '../services';
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-balham.css";

@Component({
  selector: 'app-country-table',
  templateUrl: './country-table.component.html'
})
export class CountryTableComponent implements OnInit {
  allCountryData: CountryData[];    
  public gridApi;
  public rowSelection;
  public columnDefs;

  constructor(private readonly countryApiService :PaymentsenseCodingChallengeApiService) {     
    
  }

  ngOnInit() {
    this.getData();    
  }  

  getData(){
     this.countryApiService.getCountryData().subscribe(result => this.allCountryData = result);     
  }

  updateGrid()
  {  
    this.columnDefs = [
        { headerName: 'Name', cellStyle: {textAlign: 'left'}, minWidth:500, field: 'name' },
        { field: 'flag', minWidth: 1000, cellStyle: {textAlign: 'left'},
                cellRenderer: function(params) {
                  let flagUrl = params.data["flag"];
                  let imgTag = 
                  `<img border="0" width="30" height="20" src=\"${flagUrl}\">`;
                  return imgTag;
        }}
    ];

  }

  onGridReady(params) {
    this.gridApi = params.api;
    this.gridApi.setRowData(this.allCountryData);
    this.updateGrid();
    this.rowSelection = 'single';
  }

}
