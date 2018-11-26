import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Component({
    selector: 'wallets',
    templateUrl: './wallets.component.html',
    styleUrls: ['./wallets.component.css']
})
    
export class WalletsComponent {
    private headers: Headers;
    private accessPointUrl: string = 'http://localhost:58339/api/wallet/walletaccounts/';
    private userID: number = 5;

    public allWalletAccounts = [];
    public activeWalletAccount = [];

    constructor(private http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });
        this.getWallets();
    }

    public getWallets() {
        // Get all user walletAccounts
        var dt = this.http.get(this.accessPointUrl + 'getuserwalletaccounts/' + this.userID, { headers: this.headers });
        dt.subscribe((data: any) => { this.allWalletAccounts = JSON.parse(data._body), this.activeWalletAccount = this.allWalletAccounts[0]});
        
    }

    public add(payload) {
        return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
    }

    public remove(payload) {
        return this.http.delete(this.accessPointUrl + '/' + payload.id, { headers: this.headers });
    }

    public update(payload) {
        return this.http.put(this.accessPointUrl + '/' + payload.id, payload, { headers: this.headers });
    }

    public fomartBalance(nmbr) {
        if (isNaN(nmbr)) nmbr = 0;
        return parseFloat(nmbr).toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2});
    }
}
