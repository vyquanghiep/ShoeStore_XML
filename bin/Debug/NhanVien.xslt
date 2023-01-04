<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
	<xsl:param name="Data"></xsl:param>
    <xsl:template match="/NewDataSet">
		<html>
			<body>
				<br />
				<br />
				<center>
					<h1>DANH SÁCH QUẢN LÝ NHÂN VIÊN</h1>
				</center>

				<br />

				<br />
				<table border="1" width="100%">
					<tr>
						<th>STT</th>
						<th>Mã Nhân Viên</th>
						<th>Tên Nhân Viên</th>
						<th>Ngày Sinh</th>
						<th>Địa Chỉ</th>
						<th>Số Điện Thoại</th>
						<th>Email</th>
					</tr>

					<xsl:for-each select="NhanVien">
						<xsl:if test="MaNhanVien[.=$Data]">
							<tr>
								<td>
									<xsl:value-of select="position()"/>
								</td>
								<td>
									<xsl:value-of select="MaNhanVien"/>
								</td>
								<td>
									<xsl:value-of select="TenNhanVien"/>
								</td>
								<td>
									<xsl:value-of select="NgaySinh"/>
								</td>
								<td>
									<xsl:value-of select="DiaChi"/>
								</td>
								<td>
									<xsl:value-of select="SDT"/>
								</td>
								<td>
									<xsl:value-of select="Email"/>
								</td>
							</tr>
						</xsl:if>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
