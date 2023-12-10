import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CountriesService, Country } from '../../../services/countries.service';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CacheService } from '../../../services/cache.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-countries-list',
  standalone: true,
  imports: [MatTableModule, CommonModule, MatTooltipModule, RouterModule, MatProgressSpinnerModule,],
  templateUrl: './countries-list.component.html',
  styleUrl: './countries-list.component.css'
})
export class CountriesListComponent implements OnInit, OnDestroy {
  public countries!: Country[];
  private cacheSubscription!: Subscription;
  displayedColumns: string[] = ['name', 'capital', 'currencies', 'languages', 'region'];
  showLoader: boolean = false;

  constructor(private countriesService: CountriesService, private cacheService: CacheService)
  {

  }
  ngOnInit(): void {
    this.cacheSubscription = this.cacheService.cache$.subscribe(data => {
      this.countries = data as Country[]; 
    });
    const cachedData = this.cacheService.get("countries_cache") as Country[];
    //this.countries = cachedData;
    if(cachedData == null)
    {
      this.showLoader = true;
      this.countriesService.GetAll().subscribe(data => {
        this.cacheService.set("countries_cache", data);
        this.showLoader = false;
      })
    }
  }

  ngOnDestroy(): void {
    this.cacheSubscription.unsubscribe();
    //this.cacheService.clear("countries_cache");
  }
}
