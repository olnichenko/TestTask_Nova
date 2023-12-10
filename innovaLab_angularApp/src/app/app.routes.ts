import { Routes, provideRouter } from '@angular/router';
import { CountriesListComponent } from '../components/countries/countries-list/countries-list.component';
import { CountryDetailsInfoComponent } from '../components/countries/country-details-info/country-details-info.component';

export const routes: Routes = [
    { path: '', component: CountriesListComponent },
    { path: 'countries-list', component: CountriesListComponent },
    { path: 'country/:name', component: CountryDetailsInfoComponent}
    //[path: 'user/:id/details', component:userComponent, pathMatch: 'full']
];

