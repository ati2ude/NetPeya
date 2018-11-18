import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { WalletsComponent } from './components/wallets/wallets.component';
import { RecipientsComponent } from './components/recipients/recipients.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        WalletsComponent,
        RecipientsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'wallets', pathMatch: 'full' },
            { path: 'wallets', component: WalletsComponent },
            { path: 'recipients', component: RecipientsComponent },
            { path: '**', redirectTo: 'wallets' }
        ])
    ]
})
export class AppModuleShared {
}
