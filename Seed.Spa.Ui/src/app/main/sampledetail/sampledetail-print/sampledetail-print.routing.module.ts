import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleDetailPrintComponent } from './sampledetail-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: SampleDetailPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  SampleDetailPrintRoutingModule {

}