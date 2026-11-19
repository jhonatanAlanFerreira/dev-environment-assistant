import { Routes } from '@angular/router';
import { EnvironmentDashboard } from './pages/environment-dashboard/environment-dashboard';

export const routes: Routes = [
	{ path: '', component: EnvironmentDashboard },
	{ path: '**', redirectTo: '' }
];
