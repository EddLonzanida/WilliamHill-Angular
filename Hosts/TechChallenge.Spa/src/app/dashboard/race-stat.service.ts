import { Injectable, Inject } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import { RaceStatResponse } from './responses/race-stat-response';

@Injectable()
export class RaceStatService {

    private baseUrl: string;
    constructor(private http: Http, private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }
    getStats() {
        return this.http.get(`${this.baseUrl}dashboard`)
            .toPromise()
            .then(res => {
                return <RaceStatResponse>res.json();
            })
            .then(data => { return data; })
            ;
    }
}
