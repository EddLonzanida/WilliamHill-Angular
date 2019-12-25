import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SearchResponseBase } from '../responses/search-response-base';
import { appSettings } from 'src/environments/environment';

@Injectable(({ providedIn: 'root' }) as any)
export class SearchService {
  private readonly baseUrl: string;

  constructor(private readonly httpClient: HttpClient) {
    this.baseUrl = appSettings.apiRoot;
  }

  getSuggestions(controller: string, query: string) {
    const action = 'suggestions';
    const route = `${controller}/${action}`;
    const param = { search: query };

    return this.request<string[]>('getSuggestions', route, param);
  }

  search<TRequest, TResponse>(route: string, request: TRequest) {
    return this.request<SearchResponseBase<TResponse>>('search', route, request);
  }

  request<TResponse>(operation: string, route: string, params?: any): Observable<TResponse> {
    const httpParams = this.toHttpParams(params);
    const config = { params: httpParams };
    const url = `${this.baseUrl}${route}`;

    return this.httpClient.get<TResponse>(url, config).pipe(
      catchError(this.handleError<TResponse>(operation, {} as TResponse))
    );
  }

  private toHttpParams(obj: object): HttpParams {
    let params = new HttpParams();

    if (!obj) { return params; }

    for (const key in obj) {
      if (obj.hasOwnProperty(key)) {

        const val = obj[key];

        if (val !== null && val !== undefined) {
          params = params.append(key, val.toString());
        }
      }
    }
    return params;
  }

  private log(message: string) {
    console.log(message);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      // console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      // return of(result as T);
      return throwError(error);
    };
  }
}
