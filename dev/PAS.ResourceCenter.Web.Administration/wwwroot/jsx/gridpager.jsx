var GridPager = React.createClass({
    render: function () {
        var li = [];
        var pageCount = this.props.Size;

        var fromPage = (this.props.currentPage - 1) * 50 + 1;
        var toPage = this.props.currentPage * 50;

        if (toPage > this.props.totalRecord) {
            toPage = this.props.totalRecord;
        }

        if (this.props.totalRecord > 0) {
            if (pageCount > 1) {
                for (var i = 1; i <= pageCount; i++) {
                    if (this.props.currentPage == i) {
                        li.push(<li key={i} className="active" style={{ zIndex: '0' }}><a href="#">{i}</a></li>);
                    }
                    else {
                        li.push(<li key={i}><a href="#" onClick={this.props.onPageChanged.bind(null, i)}>{i}</a></li>);
                    }
                }

                var prev = this.props.currentPage - 1;
                if (prev <= 0) {
                    prev = 1;
                }

                var next = this.props.currentPage + 1;
                if (next > pageCount) {
                    next = this.props.currentPage;
                }

                return (<div>
                    <div className="pull-left">
                        <ul className="pagination">
                            <li><a href="#" onClick={this.props.onPageChanged.bind(null, prev)} className="fa fa-chevron-left"></a></li>
                            {li}
                            <li><a href="#" onClick={this.props.onPageChanged.bind(null, next)} className="fa fa-chevron-right"></a></li>
                        </ul>
                    </div>
                    <div className="pull-left" style={{ marginTop: '25px' }}>
                        <div className="search-result-rec-count hidden-xs">
                            &nbsp;&nbsp;Showing <b>{fromPage.toString()}</b>-<b>{toPage.toString()}</b> of <b>{this.props.totalRecord.toString()}</b>
                            &nbsp;&nbsp;Records (<i>{this.props.totalRecord.toString()}</i> found<sup>1</sup>)
                                </div>
                    </div>
                </div>);
            }
            else {
                return (<div>
                    <div className="pull-left" style={{ marginTop: '25px', marginBottom: '25px' }}>
                        <div className="search-result-rec-count hidden-xs">
                            &nbsp;&nbsp;Showing <b>{fromPage.toString()}</b>-<b>{toPage.toString()}</b> of <b>{this.props.totalRecord.toString()}</b>
                            &nbsp;&nbsp;Records (<i>{this.props.totalRecord.toString()}</i> found<sup>1</sup>)
                                </div>
                    </div>
                </div>);
            }
        }
        else {
            return (<div></div>);
        }
    }
});