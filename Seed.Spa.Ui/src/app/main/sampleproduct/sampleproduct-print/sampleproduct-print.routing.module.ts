import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleProductPrintComponent } from './sampleproduct-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: SampleProductPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  SampleProductPrintRoutingModule {

}