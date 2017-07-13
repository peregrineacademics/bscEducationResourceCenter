var ReviewerGridRow = React.createClass({
    render: function () {
        return (<div className="row well padding-10">
                    <div className="padding-left-0">
                        <div>
                            <a href={'/Reviewers/Edit?Id=' + this.props.item.id.toString()} style={{ fontFamily: 'Times New Roman', fontSize: '24px' }}>{this.props.item.screenName}&nbsp;({this.props.item.enabled ? <i className="fa fa-check" style={{ color: 'green' }} /> : <i className="fa fa-remove" style={{ color: 'lightgray' }} />})</a>
                            <div className="pull-right">
                            <a className="btn btn-default" href={'/Reviewers/Edit?Id=' + this.props.item.id.toString()}><i className="fa fa-pencil"></i>&nbsp;Edit</a>
                            &nbsp;
                                <a className="btn btn-default" href={'/Home'}><i className="fa fa-comments"></i>&nbsp;Reviews&nbsp;({this.props.item.reviewsCount.toString()})</a>
                            </div>
                        </div>
                        <div className="margin-top-0">
                            <span style={{ fontSize: '13px', color: 'gray' }}>
                                Name:&nbsp;<b>{this.props.item.fullName}</b>
                                <br />
                                Email:&nbsp;<b>{this.props.item.email}</b>
                                <br />
                                Hidden:&nbsp;<b>{this.props.item.hideFromReviewerList ? 'Yes' : 'No'}</b>
                                <br />
                                Active:&nbsp;<b>{this.props.item.IsActiveReviewer ? 'Yes' : 'No'}</b>
                            </span>
                            <br />
                            <span style={{ fontSize: '13px', color: 'gray' }}>
                                Biography:&nbsp;
                            </span>
                        </div>
                        <p style={{ textAlign: 'justify', marginTop: '8px' }}>
                            {this.props.item.biography}
                        </p>
                        <div style={{ marginTop: '15px' }}>
                            <span style={{ fontSize: '11px', color: 'gray' }}>
                                Created:&nbsp;{this.props.item.created}
                            </span>
                            <br />
                            <span style={{ fontSize: '11px', color: 'gray' }}>
                                Updated:&nbsp;{this.props.item.modified}
                            </span>
                        </div>
                    </div>
                </div>)
    }
});

var ReviewerGridTable = React.createClass({
    getInitialState: function () {
        return {
            loading: true,
            data: {
                list: [],
                totalRecord: 0,
                totalPage: 0,
                searchName: '',
                sortColumnName: '',
                sortOrder: '',
                currentPage: 1,
                pageSize: 50
            }
        }
    },

    componentDidMount: function () {
        this.populateData();
    },

    componentWillUnmount: function () {
    },

    populateData: function () {
        var params = {
            pageSize: this.state.data.pageSize,
            currentPage: this.state.data.currentPage
        }

        if (this.state.data.searchName) {
            params.searchName = this.state.data.searchName;
        }

        if (this.state.data.sortColumnName) {
            params.sortColumnName = this.state.data.sortColumnName;
        }

        if (this.state.data.sortOrder) {
            params.sortOrder = this.state.data.sortOrder;
        }

        this.setState({
            loading: true
        });

        $.ajax({
            url: this.props.dataUrl,
            type: 'GET',
            data: params,
            success: function (data) {
                if (this.isMounted()) {
                    this.setState({
                        loading: false,
                        data: data
                    });
                }
            }.bind(this),
            error: function (err) {
                //return alert('Error: ' + err.toString());
            }.bind(this),
            complete: function (response, status) {
                //return alert("Completed: " + status);
            }.bind(this)
        });
    },

    pageChanged: function (pageNumber, e) {
        this.state.data.currentPage = pageNumber;
        this.populateData();
    },

    sortChanged: function (sortColumnName, order, e) {
        e.preventDefault();
        this.state.data.sortColumnName = sortColumnName;
        this.state.data.currentPage = 1;
        this.state.data.sortOrder = order.toString().toLowerCase() == 'asc' ? 'desc' : 'asc';
        this.populateData();
    },

    searchChanged: function (e) {
        e.preventDefault();
        this.state.data.currentPage = 1;
        this.state.data.sortColumnName = "ScreenName";
        this.state.data.sortOrder = "asc";
        this.state.data.searchName = document.getElementById("inputSearchName").value.trim();

        this.populateData();
    },

    resetChanged: function (e) {
        e.preventDefault();
        this.state.data.currentPage = 1;
        this.state.data.sortColumnName = "ScreenName";
        this.state.data.sortOrder = "asc";
        this.state.data.searchName = '';
        this.populateData();

        document.getElementById("inputSearchName").value = '';
    },

    render: function () {
        var rows = [];
        this.state.data.list.forEach(function (item) {
            rows.push(
                <ReviewerGridRow key={item.id} item={item} />);
        });

        return (<div>
            {/* Filter Section */}
            <div id="gridsearch-filter" className="panel panel-default collapsable">
                <div className="panel-heading">
                    <a data-toggle="collapse" data-parent="#gridsearch-filter" data-animate="true"
                        href="#gridsearch-fields" style={{ color: 'inherit' }}>
                        <i className="fa fa-angle-down toggler"></i>
                        &nbsp;Filter results using the criteria below
                            </a>
                </div>
                <div id="gridsearch-fields" className="panel-body fields collapse in">                    
                    <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                        <input id="inputSearchName" className="form-control" ref="inputSearchName" type="search" placeholder="Search by Name or Email" />
                    </div>
                    <div className="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                    </div>
                </div>
            </div>

            {/* Button Section */}
            <div className="row" style={{ marginLeft: '0px', marginRight: '0px' }}>
                {this.state.loading ?
                    <div className="pull-left">
                        <div>
                            &nbsp;&nbsp;Loading, Please wait...
                                </div>
                    </div>
                    :
                    <div style={{ marginTop: '-20px' }}>

                        {/* Search and Reset */}
                        <div className="pull-right">
                            <div style={{ marginTop: '18px' }}>
                                <button id="buttonSearch" className="btn btn-primary" onClick={this.searchChanged}>
                                    <span className="hidden-xs">Search</span>
                                    <span className="visible-xs"><i className="fa fa-search"></i>&nbsp;Search</span>
                                </button>
                                &nbsp;
                                        <button className="btn btn-default" onClick={this.resetChanged}>
                                    <span className="hidden-xs">Reset</span>
                                    <span className="visible-xs"><i className="fa fa-undo"></i></span>
                                </button>
                                &nbsp;
                            </div>
                        </div>

                        {/* Paging */}
                        <GridPager Size={this.state.data.totalPage} onPageChanged={this.pageChanged} currentPage={this.state.data.currentPage} totalRecord={this.state.data.totalRecord} />

                    </div>
                }
            </div>

            {/* Data Table */}
            <div>
                {this.state.loading ? <div></div> :
                    <div>
                        {this.state.data.totalRecord == 0 ?
                            <div><div style={{ color: 'Red', marginTop: '-60px' }}><h6><strong><em><br />No results were returned.</em></strong></h6></div></div>
                            :
                            <div>
                                <div className="padding-10">
                                    {rows}
                                </div>
                            </div>
                        }
                    </div>
                }
            </div>
        </div>)
    }
});

ReactDOM.render(<ReviewerGridTable dataUrl="/reviewers/list" />, document.getElementById('divgriddata'));