import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Navigation } from "@angular/router";
import { environment } from "environments/environment";
import { Guid } from "guid-typescript";
import { Observable } from "rxjs";

@Injectable()
export class ApiService {
    baseUrl: string;
    env = environment;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') _baseUrl: string
    ) {
        this.baseUrl = _baseUrl;
    }

    getHeaderNodeRed(): HttpHeaders {
        return localStorage.getItem('accessToken') ? new HttpHeaders({
            'Content-Type': 'application/json',
            'id': localStorage.getItem('userId'),
            'token': localStorage.getItem('accessToken')
        }) : new HttpHeaders({
            'Content-Type': 'application/json'
        });
    }

    getHeader(): HttpHeaders {
        return localStorage.getItem('accessToken') ? new HttpHeaders({
            'Content-Type': 'application/json',
            'id': localStorage.getItem('userId'),
            "Authorization": "Bearer " + localStorage.getItem('accessToken')
        }) : new HttpHeaders({
            'Content-Type': 'application/json'
        });
    }

    actionItem(actionTable: string, action: string, item: any) {
        item.actionTable = actionTable;
        item.action = action;
        return this.http.post(this.env.apiUrl + 'action', item, { headers: this.getHeaderNodeRed() });
    }

    get(controller: string) {
        return this.http.get(this.baseUrl + 'api/' + controller, { headers: this.getHeaderNodeRed() });
    }

    getById(controller: string, id: Guid) {
        return this.http.get(this.baseUrl + 'api/' + controller + '/' + id, { headers: this.getHeaderNodeRed() });
    }

    post(controller: string, tag: string, data: any) {
        if ((controller === 'directories' && tag === 'category') || (controller === 'status' && tag === 'table')) {
            return this.http.post(this.baseUrl + 'api/' + controller + '/' + tag + '/' + data, data, { headers: this.getHeaderNodeRed() });
        } else {
            return this.http.post(this.baseUrl + 'api/' + controller + (tag ? '/' + tag : ''), data, { headers: this.getHeaderNodeRed() });
        }
    }

    put(controller: string, data: any) {
        return this.http.put(this.baseUrl + 'api/' + controller, data, { headers: this.getHeaderNodeRed() });
    }

    delete(controller: string, id: Guid) {
        return this.http.post(this.baseUrl + 'api/' + controller + '/delete/' + id, { headers: this.getHeaderNodeRed() });
    }

    signIn(item) {
        return this.http.post(this.baseUrl + 'users/sign-in', item, { headers: this.getHeader() });
    }

    getNavigation() {
        return this.http.get<Navigation>(this.baseUrl + 'navigation', { headers: this.getHeader() });
    }

    upload(model, formData, filename) {
        return this.http.post(this.baseUrl + 'api/' + model + '/uploadImage/' + filename, formData, { reportProgress: true, observe: 'events' });
    }


    


    contactUs(email) {
        return this.http.post(environment.apiUrlLunkulu + 'contact-us', { 'email': email }, { responseType: 'json' });
    }

    resetPassword(id, password) {
        return this.http.post(environment.apiUrlLunkulu + 'reset-password', { id: id, password: password });
    }

    sendEmail(clientId: Guid, prospectId: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'email' + '?clientId=' + clientId + '&prospectId=' + prospectId, { responseType: 'json' });
    }

    getData(table: string, id: Guid) {
        return this.http.get(environment.apiUrlLunkulu + table + '?id=' + id, { responseType: 'json' });
    }

    getNotes(clientId: Guid, createdBy: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'clientNote?clientId=' + clientId + '&createdBy=' + createdBy, { responseType: 'json' });
    }

    getDataByUser(table: string, id: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'user/' + table + '?id=' + id, { responseType: 'json' });
    }

    getView(table: string, id: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'view/' + table + '?id=' + id, { responseType: 'json' });
    }

    getViewByUser(table: string, id: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'view/user/' + table + '?id=' + id, { responseType: 'json' });
    }

    getTimesheetsReady(clientId: Guid, invoiceId: Guid) {
        return this.http.get(environment.apiUrlLunkulu + 'timesheet/invoice?clientId=' + clientId + '&invoiceId=' + invoiceId, { responseType: 'json' });
    }

    insertItem(table: string, item: any) {
        return this.http.post(environment.apiUrlLunkulu + table + '/insert', item, { responseType: 'json' });
    }

    updatItem(table: string, item: any) {
        return this.http.post(environment.apiUrlLunkulu + table + '/update', item, { responseType: 'json' });
    }

    deleteItem(table: string, item: any) {
        return this.http.post(environment.apiUrlLunkulu + table + '/delete', item, { responseType: 'json' });
    }

    deleteChildren(table: string, item: any) {
        return this.http.post(environment.apiUrlLunkulu + table + '/deleteChildren', item, { responseType: 'json' });
    }

    getList(table: string, id: Guid): Observable<any[]> {
        table = table.trim();

        return this.http.get<any[]>(environment.apiUrlLunkulu + table + '?id=' + id, { responseType: 'json' })
            .pipe();
    }
}