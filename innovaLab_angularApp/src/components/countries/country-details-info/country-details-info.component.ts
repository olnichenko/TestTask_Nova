import { Component, OnInit } from '@angular/core';
import { CountriesService, CountryDetailInfo } from '../../../services/countries.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


@Component({
  selector: 'app-country-details-info',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, CommonModule, MatListModule, MatProgressSpinnerModule],
  templateUrl: './country-details-info.component.html',
  styleUrl: './country-details-info.component.css'
})
export class CountryDetailsInfoComponent implements OnInit {
  public countryDetailsInfo: CountryDetailInfo | undefined;
  constructor(private route: ActivatedRoute, private countriesService: CountriesService, private router: Router) { }
  ngOnInit(): void {
    let countryName = this.route.snapshot.paramMap.get('name') as string;
    this.countriesService.GetCountryInfo(countryName).subscribe(data => {
      this.countryDetailsInfo = data;
    })
  }

  NavigateToList() {
    this.router.navigateByUrl('/countries-list');
  }

}
