import { Currency } from "./currency.model";
import { Language } from "./language.model";

export class CountryData {
    name: string;
    flag: string;
    population: number;
    timeZones: string[];
    capital: string;
    borders: string[];
    currencies: Currency[];
    languages: Language[];    
}
