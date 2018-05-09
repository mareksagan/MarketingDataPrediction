﻿import * as React from "react";
import * as ReactDOM from "react-dom";
import { XYPlot, XAxis, YAxis, HorizontalGridLines, LineSeries } from 'react-vis';
import { RouteComponentProps } from "react-router";

const timestamp = new Date('May 23 2017').getTime();
const ONE_DAY = 86400000;

const DATA = [
    { x0: ONE_DAY * 2, x: ONE_DAY * 3, y: 1 },
    { x0: ONE_DAY * 7, x: ONE_DAY * 8, y: 1 },
    { x0: ONE_DAY * 8, x: ONE_DAY * 9, y: 1 },
    { x0: ONE_DAY * 9, x: ONE_DAY * 10, y: 2 },
    { x0: ONE_DAY * 10, x: ONE_DAY * 11, y: 2.2 },
    { x0: ONE_DAY * 19, x: ONE_DAY * 20, y: 1 },
    { x0: ONE_DAY * 20, x: ONE_DAY * 21, y: 2.5 },
    { x0: ONE_DAY * 21, x: ONE_DAY * 24, y: 1 }
].map(el => ({ x0: el.x0 + timestamp, x: el.x + timestamp, y: el.y }));

export class WyswietlStatystykiSystemu extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return (
            <XYPlot
                xDomain={[timestamp - 2 * ONE_DAY, timestamp + 30 * ONE_DAY]}
                yDomain={[0.1, 2.1]}
                xType="time"
                width={300}
                height={300} >
                <VerticalGridLines />
                <HorizontalGridLines />
                <XAxis />
                <YAxis />
                <VerticalRectSeries data={DATA} style={{ stroke: '#fff' }} />
            </XYPlot>
        );
    }
}
