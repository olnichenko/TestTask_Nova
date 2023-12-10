import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  constructor(private httpClient: HttpClient) { }

  public GetAll() : Observable<Country[]>{
    return this.httpClient.get<Country[]>("http://localhost:5288/api/Countries/GetCountries");
  }

  public GetCountryInfo(name: string): Observable<CountryDetailInfo>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("name", name);
    return this.httpClient.get<CountryDetailInfo>("http://localhost:5288/api/Countries/GetCountry", {params: queryParams})
  }
}

export interface CountryDetailInfo extends Country{
  flags: Flag;
  maps: Maps;
}

export interface Country {
  name: CountryName;
  currencies: { [key: string]: Currency; } | null;
  capital: string[];
  region: string;
  languages: { [key: string]: string; } | null;
}

export interface CountryName {
  official: string;
  common: string;
}

export interface Currency {
  name: string | null;
  symbol: string | null;
}

export interface Maps {
  googleMaps: string;
  openStreetMaps: string;
}

export interface Flag {
  png: string;
  svg: string;
  alt: string;
}
