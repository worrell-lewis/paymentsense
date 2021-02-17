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
  }  

  getData(){
     this.countryApiService.getCountryData().subscribe(result => {this.allCountryData = result;
                                                                  this.gridApi.setRowData(this.allCountryData)});     
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
    this.getData();
    this.updateGrid();
    this.rowSelection = 'single';
  }

  onRowSelected(params) {
    // AG grid calls the onRowSelected twice once when for the current selection and a second time for the unselection of the previous.
    // Hence we proceed only if it is the selected row.
    if (!params.node.selected)
      return;

    const selectedRow = params;
    var laguageNames = selectedRow.data.languages.map(a => a.name);
    var currencyNames = selectedRow.data.currencies.map(a => a.name);
    
    alert("Country Additional Details \n"+
            "Name : " +selectedRow.data.name +
            "\nCapital : "+selectedRow.data.capital+
            "\nPopulation : "+ selectedRow.data.population.toString() +
            "\nTime Zones : "+ selectedRow.data.timeZones.toString() +
            "\nLanguages : " + laguageNames.toString()+
            "\nBorders : "+selectedRow.data.borders.toString()+
            "\nCurrencies : "+currencyNames.toString());
    
  }
}
