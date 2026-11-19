import { Component, inject, signal } from '@angular/core';
import { DatePipe, NgClass } from '@angular/common';
import { EnvironmentApiService, EnvironmentModel, CheckRun, ServiceModel } from '../../core/environment-api.service';

const DEMO_ENVIRONMENT_ID = '11111111-1111-1111-1111-111111111111';

@Component({ selector: 'app-environment-dashboard', imports: [DatePipe, NgClass], templateUrl: './environment-dashboard.html', styleUrl: './environment-dashboard.scss' })
export class EnvironmentDashboard {
  private readonly api = inject(EnvironmentApiService);
  readonly environment = signal<EnvironmentModel | null>(null);
  readonly checkRun = signal<CheckRun | null>(null);
  readonly loading = signal(true);
  readonly checking = signal(false);
  readonly error = signal('');

  constructor() { this.loadEnvironment(); }
  loadEnvironment(): void { this.loading.set(true); this.error.set(''); this.api.getEnvironment(DEMO_ENVIRONMENT_ID).subscribe({ next: value => { this.environment.set(value); this.loading.set(false); }, error: () => { this.error.set('The configured environment could not be reached. Start the backend and try again.'); this.loading.set(false); } }); }
  runChecks(): void { this.checking.set(true); this.api.runChecks(DEMO_ENVIRONMENT_ID).subscribe({ next: value => { this.checkRun.set(value); this.checking.set(false); }, error: () => { this.error.set('Checks could not be completed. Verify that the backend is running.'); this.checking.set(false); } }); }
  serviceStatus(service: ServiceModel): string { return service.status.toLowerCase(); }
  checkCount(status: string): number { return this.checkRun()?.serviceResults.filter(result => result.status === status).length ?? 0; }
}