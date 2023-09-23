import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginScreenComponent } from './login-screen/login-screen.component';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { HomeScreenComponent } from './home-screen/home-screen.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthGuard } from '../services/auth.guard';
import { AppRoutingModule } from './app-routing.module';
import { Constants } from 'src/constants';
import { ModalContentComponent } from './modal-content/modal-content.component';
import { CommonModule, registerLocaleData } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ModalArchiveComponent } from './modal-archive/modal-archive.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import en from '@angular/common/locales/en';
import { NgZorroAntdModule } from './ng-zorro-ant.module';
import { TokenInterceptor } from './token.interceptor';
import { BannerCardComponent } from './home-screen/banner-card/banner-card.component';
import { CurrentValuesCardComponent } from './home-screen/instant-values-card/instant-values-card.component';
import { DirtHistoryCardComponent } from './home-screen/dirt-history-card/dirt-history-card.component';
import { DynamicDirtCardComponent } from './home-screen/dynamic-dirt-card/dynamic-dirt-card.component';
import { EvapotranspiratsiyaHistoryCardComponent } from './home-screen/evapotranspiratsiya-history-card/evapotranspiratsiya-history-card.component';
import { HumadityHistoryCardComponent } from './home-screen/humadity-history-card/humadity-history-card.component';
import { MapCardComponent } from './home-screen/map-card/map-card.component';
import { SandHumadityHistoryCardComponent } from './home-screen/sand-humadity-history-card/sand-humadity-history-card.component';
import { SandTemperatureHistoryCardComponent } from './home-screen/sand-temperature-history-card/sand-temperature-history-card.component';
import { SolarRadiationHistoryCardComponent } from './home-screen/solar-radiation-history-card/solar-radiation-history-card.component';
import { TemperatureHistoryCardComponent } from './home-screen/temperature-history-card/temperature-history-card.component';
import { WindHistoryCardComponent } from './home-screen/wind-history-card/wind-history-card.component';
import { HighchartsChartModule } from 'highcharts-angular';

registerLocaleData(en);
@NgModule({
    declarations: [
        AppComponent,
        LoginScreenComponent,
        MainScreenComponent,
        HomeScreenComponent,
        BannerCardComponent,
        CurrentValuesCardComponent,
        DirtHistoryCardComponent,
        DynamicDirtCardComponent,
        EvapotranspiratsiyaHistoryCardComponent,
        HumadityHistoryCardComponent,
        MapCardComponent,
        SandHumadityHistoryCardComponent,
        SandTemperatureHistoryCardComponent,
        SolarRadiationHistoryCardComponent,
        TemperatureHistoryCardComponent,
        WindHistoryCardComponent,
        ModalContentComponent,
        ModalArchiveComponent
    ],
    imports: [
        BrowserModule,
        NgbModule,
        FormsModule,
        HttpClientModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
        NgZorroAntdModule,
        HighchartsChartModule,
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
        AuthGuard, Constants, { provide: NZ_I18N, useValue: en_US }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
