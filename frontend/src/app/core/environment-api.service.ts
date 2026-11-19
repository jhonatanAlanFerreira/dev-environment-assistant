import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

export type ServiceStatus = 'Healthy' | 'Degraded' | 'Stopped' | 'Unknown';
export type CheckStatus = 'Pass' | 'Fail' | 'Warning' | 'Skipped';
export interface ServiceModel { id: string; name: string; status: ServiceStatus; host: string; port: number; dependencyIds: string[]; notes: string; }
export interface EnvironmentModel { id: string; name: string; localCodebasePaths: string[]; testUrls: string[]; services: ServiceModel[]; updatedAt: string; }
export interface CheckResult { id: string; serviceId: string | null; serviceName: string; checkType: string; status: CheckStatus; output: string; timestamp: string; }
export interface CheckRun { runId: string; serviceResults: CheckResult[]; summary: string; timestamp: string; }

@Injectable({ providedIn: 'root' })
export class EnvironmentApiService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:5000/api';

  getEnvironment(id: string): Observable<EnvironmentModel> { return this.http.get<EnvironmentModel>(`${this.baseUrl}/environments/${id}`); }
  runChecks(id: string): Observable<CheckRun> { return this.http.post<CheckRun>(`${this.baseUrl}/environments/${id}/checks`, {}); }
}