import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { InvestimentoRequest, Response, InvestimentoResponse, RendimentoResponse } from "./investimento.model";
import { Observable } from "rxjs";


@Injectable({
      providedIn: 'root'  
})

export class InvestimentoCdbService {

    baseUrl = 'http://localhost:5009/api/investimentocdb';
    
    constructor(private http: HttpClient) {}

    simular(request: InvestimentoRequest): Observable<Response> {
        let url = `${this.baseUrl}/calcular-investimento`;
        
        return this.http.post<Response>(url, request);
    }
}