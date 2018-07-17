import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleStandartPrintComponent } from './samplestandart-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: SampleStandartPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  SampleStandartPrintRoutingModule {

}